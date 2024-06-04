using ControlInventario.Core.Models;
using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Datos.DTO;
using ControlInventario.WebApi.Models;

namespace ControlInventario.Core.Repositories.Interfaces;
public interface IInventarioRepositorio
{
    Task<DtoBaseResponse> IngresarMercancia(int providerCatalogArticleId, int cantidad, CancellationToken cancellationToken);
    Task<DtoBaseResponse> IngresarMercanciaPorOrden(SeleccionOrdenRequestModel orden, CancellationToken cancellationToken);
    Task<Inventario> ListarArticulos(PageListRequestModel plrm, CancellationToken cancellationToken);
    Task<DtoBaseResponse> AplicarROPInventario();
    Task<DtoBaseResponse> AplicarVerificarMinMax();
    Task<DtoBaseResponse> AplicarMantenerMaximo();
    Task<DtoBaseResponse> AplicarNivelesMercado();
}