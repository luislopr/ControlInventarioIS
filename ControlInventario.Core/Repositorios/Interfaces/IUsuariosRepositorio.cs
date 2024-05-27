using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Datos.DTO;

namespace ControlInventario.Core.Repositories.Interfaces;
public interface IUsuariosRepositorio
{
    void SetUser(DtoUser user);
    DtoUser GetUser();   
    Task<Usuario> ObtenerUsuarioCredenciales(string username, string password, CancellationToken cancellationToken = default);
    Task<Usuario> CrearUsuario(Usuario usuario, CancellationToken cancellationToken = default);
    Task<List<DtoUsuario>> GetUsuarios(CancellationToken cancellationToken);
}