using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Core.Repositorios.Interfaces;
using ControlInventario.Data.Models.Helpers;
using ControlInventario.Core.Repositorios;
using ControlInventario.Gateway.Models;
using ControlInventario.WebApi.Models;
using ControlInventario.Core.Helpers;
using Microsoft.Extensions.Options;
using ControlInventario.Datos.DTO;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace ControlInventario.Core.Repositories;

public class CatalogoProveedorRepositorio(PostgresContext contextFactory, IOptions<AppSettings> appSettings, IUsuariosRepositorio usuariosRepositorio)
    : Repository<PostgresContext, CatalogoProveedor>(contextFactory, appSettings), ICatalogoProveedorRepositorio
{
    private readonly IUsuariosRepositorio _usuariosRepositorio = usuariosRepositorio;
    public async Task<CatalogoProveedor> ObtenerArticuloProveedorPorId(int id) => await base.GetById(id);
    public async Task<DtoBaseResponse> ActualizarArticulo(ArticleRequestModelExtended articleRequestModel, CancellationToken cancellationToken)
    {
        var article = this.ModelArticle(articleRequestModel);
        article.Id = articleRequestModel.ArticleId;
        await base.UpdateAsync(article, cancellationToken);
        return new() { Message = "Artículo Actualizado" };
    }
    public async Task<DtoBaseResponse> CargarArticulo(ArticleRequestModel articleRequestModel, CancellationToken cancellationToken)
    {
        var userInfo = _usuariosRepositorio.GetUser();
        var articulo = this.ModelArticle(articleRequestModel);
        await base.AddAsync(articulo, cancellationToken);

        return new() { Message = "Artículo Añadido" };
    }
    public async Task<DTOPageObjectResponse<CatalogoProveedor>> GetArticleListAsync(ArticleListRequestModel pageListRequestModel, CancellationToken cancellationToken)
    {
        var userInfo = _usuariosRepositorio.GetUser();
        string? filter = pageListRequestModel.FilterValue?.ToUpper();

        var articleList = (await base.Get(b => b.IdProveedor == pageListRequestModel.IdProveedor, cancellationToken)).ToList();

        articleList = (from a in articleList
                       where filter == null ||
                             filter == string.Empty ||
                             (a.ArticuloProveedor.ToUpper().Contains(filter) || a.CodigoBarra.ToUpper().Contains(filter))
                       orderby a.Id
                       select a)

                       .ToList();

        var maxCount = articleList.Count;

        articleList = articleList
                     .Skip(pageListRequestModel.Page * pageListRequestModel.Take)
                     .Take(pageListRequestModel.Take).ToList();

        return new()
        {
            Count = maxCount,
            Entidades = articleList
        };
    }
    public async Task<byte[]> GetExcelArticleFormat(CancellationToken cancellationToken)
    {
        string pathToFile = "./Files/ProveedorExternoFormatoCargaArticulos.xlsx";
        FileInfo fileInfo = new(pathToFile);
        ExcelPackage excelPackage = new(fileInfo);
        return await excelPackage.GetAsByteArrayAsync(cancellationToken);
    }
    public async Task<DtoBaseResponse> CargarArticulos(IFormFile excelFile, int providerId, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        try
        {
            await excelFile.CopyToAsync(stream, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }

        using var package = new ExcelPackage(stream);
        try
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            List<ExcelArticleUpload> articulosExcel = worksheet.ConvertSheetToObjects<ExcelArticleUpload>().ToList();

            articulosExcel.RemoveAll(b => !b.IsValid());
            articulosExcel = articulosExcel.DistinctBy(b => b.Código).ToList();

            List<Task<DtoBaseResponse>> tasks = new();
            foreach (var article in articulosExcel)
            {
                tasks.Add(this.CargarArticulo(articleRequestModel: new ArticleRequestModel()
                {
                    CodigoArticuloExterno = int.Parse(article.Código),
                    NombreArticulo = article.Descripción,
                    Costo = (decimal)article.PrecioVenta,
                    IVA = (decimal)article.ImpuestoVenta,
                    CodigoBarra = article.CódigoBarra,
                    IdProveedor = providerId
                }, cancellationToken));
            }

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception) { }

            string results = "";
            foreach (var item in tasks)
                if (item.Status == TaskStatus.Faulted) results += $"{item.Exception.InnerException.Message}, ";

            return new() { Message = $"Artículos Procesados.  {results}" };

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
    private CatalogoProveedor ModelArticle(ArticleRequestModel articleRequestModel)
    {
        var userInfo = _usuariosRepositorio.GetUser();
        var article = new CatalogoProveedor()
        {
            CodigoBarra = articleRequestModel.CodigoBarra,
            ArticuloProveedor = articleRequestModel.NombreArticulo,
            IdProveedor = articleRequestModel.IdProveedor,
            Costo = articleRequestModel.Costo,
            FechaCreacion = DateTime.Now
        };
        return article;
    }
}