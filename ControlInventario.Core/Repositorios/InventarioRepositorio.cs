using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Datos.DTO;
using ControlInventario.Core.Models;
using ControlInventario.WebApi.Models;
using ControlInventario.Core.Repositorios.Interfaces;
using ControlInventario.Core.Repositories;

namespace ControlInventario.Core.Repositorios;
public class InventarioRepositorio : Repository<PostgresContext, Inventario>, IInventarioRepositorio
{
    private readonly ICatalogoProveedorRepositorio _catalogoProveedorRepositorio;
    public InventarioRepositorio(PostgresContext context, ICatalogoProveedorRepositorio catalogoProveedorRepositorio) : base(context)
    { _catalogoProveedorRepositorio = catalogoProveedorRepositorio; }

    public async Task<DtoBaseResponse> AplicarMantenerMaximo()
    {
        throw new NotImplementedException();
    }

    public async Task<DtoBaseResponse> AplicarNivelesMercado()
    {
        throw new NotImplementedException();
    }

    public async Task<DtoBaseResponse> AplicarROPInventario()
    {
        throw new NotImplementedException();
    }

    public async Task<DtoBaseResponse> AplicarVerificarMinMax()
    {
        throw new NotImplementedException();
    }

    public async Task<DtoBaseResponse> IngresarMercancia(int providerCatalogArticleId, int cantidad, CancellationToken cancellationToken)
    {
        var providerArticleAux = await _catalogoProveedorRepositorio.ObtenerArticuloProveedorPorId(providerCatalogArticleId);
        var articleAux = await base.GetFirst(b => b.ProveedorId == providerArticleAux.IdProveedor && b.IdArticuloProveedor == providerArticleAux.Id, cancellationToken);

        if (articleAux == null)
        {
            articleAux = await base.AddAsync(new Inventario
            {
                CodigoArticulo = providerArticleAux.Id.ToString(),
                CodigoBarra = providerArticleAux.CodigoBarra,
                DescripciónArticulo = providerArticleAux.ArticuloProveedor,
                IdArticuloProveedor = providerArticleAux.Id,
                Costo = providerArticleAux.Costo,
                Existencia = cantidad,
                FechaCreacion = DateTime.Now,
                Precio = providerArticleAux.Costo + (providerArticleAux.Costo * (decimal)(0.23)),
                ProveedorId = providerArticleAux.IdProveedor,
            }, cancellationToken);
        }
        else
        {
            articleAux.Existencia += cantidad;
            await base.UpdateAsync(articleAux, cancellationToken);
        }
        return new();
    }

    public async Task<DtoBaseResponse> IngresarMercanciaPorOrden(SeleccionOrdenRequestModel orden, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Inventario> ListarArticulos(PageListRequestModel plrm, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
