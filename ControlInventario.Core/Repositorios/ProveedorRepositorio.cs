using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Repositorios.Interfaces;
using ControlInventario.Datos.Repositorios;
using ControlInventario.Datos.DTO;

namespace ControlInventario.Core.Repositorios;
public class ProveedorRepositorio : Repository<PostgresContext, Proveedor>, IProveedorRepositorio
{
    public ProveedorRepositorio(PostgresContext context) : base(context) { }
    public async Task<DtoBaseResponse> CrearProveedorAsync(DtoProveedor dto, CancellationToken cancellationToken)
    {
        var proveedorAux = this.AsignarDatosProveedor(dto);

        var result = await base.AddAsync(proveedorAux, cancellationToken);
        return new();
    }

    public async Task<DtoBaseResponse> EditarProveedorAsync(DtoProveedor dto, CancellationToken cancellationToken)
    {
        var proveedorAux = await base.GetFirst(b => b.Id == dto.Id, cancellationToken);
        if (proveedorAux == null) throw new InvalidOperationException("No Encontrado");

        proveedorAux = this.AsignarDatosProveedor(dto);
        await base.UpdateAsync(proveedorAux, cancellationToken);
        return new() { Message = "Cambios registrados" };
    }

    private Proveedor AsignarDatosProveedor(DtoProveedor dto)
        => new Proveedor()
        {
            Id = dto.Id,
            FechaCreacion = DateTime.Now,
            Direccion = dto.Direccion,
            DiasCredito = dto.DiasCredito,
            Email = dto.Email,
            Nombre = dto.Nombre,
            Rif = dto.Rif,
            Telefono = dto.Telefono
        };
}
