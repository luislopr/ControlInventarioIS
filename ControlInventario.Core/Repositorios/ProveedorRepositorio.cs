using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Datos.DTO;

namespace ControlInventario.Core.Repositorios;
public class ProveedorRepositorio : Repository<PostgresContext, Proveedor>, IProveedorRepositorio
{
    public ProveedorRepositorio(PostgresContext context) : base(context) { }
    public async Task<DtoBaseResponse> CargarProveedor(List<DtoProveedor> dto, CancellationToken cancellationToken)
    {
        List<Proveedor> proveedors = new();
        foreach (var item in dto)
            proveedors.Add(new Proveedor()
            {
                //FechaActualizacion = DateTime.Now,
                //UltimaActualizacionCatalogo = item.UltimaActualizacionCatalogo,
                //UsuarioAuditor = item.UsuarioAuditor,
                //Codigo = item.Codigo.ToString(),
                //FechaCreacion = item.FechaCreacion,
                //Nombre = item.Nombre,
                //Rif = item.Rif
            });

        await base.AddManyAsync(proveedors, cancellationToken); 
        return new();
    }
}
