using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.WebApi.Models;
using ControlInventario.Datos.DTO;
using Microsoft.AspNetCore.Http;

namespace ControlInventario.Core.Repositorios.Interfaces;

public interface ICatalogoProveedorRepositorio
{
    Task<DTOPageObjectResponse<CatalogoProveedor>> GetArticleListAsync(ArticleListRequestModel pageListRequestModel, CancellationToken cancellationToken);
    Task<DtoBaseResponse> CargarArticulo(ArticleRequestModel cargarArticuloProveedorRequestModel, CancellationToken cancellationToken);
    Task<DtoBaseResponse> CargarArticulos(IFormFile archivoExcel, int providerId, CancellationToken cancellationToken);
    Task<DtoBaseResponse> ActualizarArticulo(ArticleRequestModelExtended articleRequestModel, CancellationToken cancellationToken);
    Task<byte[]> GetExcelArticleFormat(CancellationToken cancellationToken);
}