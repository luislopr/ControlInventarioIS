using ControlInventario.Datos.DTO;
using ControlInventario.Datos.Repositorios;

namespace ControlInventario.Core.Repositorios.Interfaces;
public interface IProveedorRepositorio
{
    Task<DtoBaseResponse> CrearProveedorAsync(DtoProveedor dtoProveedor, CancellationToken cancellationToken);
    Task<DtoBaseResponse> EditarProveedorAsync(DtoProveedor dtoProveedor, CancellationToken cancellationToken);
}