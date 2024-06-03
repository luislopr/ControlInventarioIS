using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Core.Repositorios;
using ControlInventario.Core.Helpers;
using Microsoft.Extensions.Options;
using ControlInventario.Datos.DTO;

namespace ControlInventario.Core.Repositories;

public class UsersRepositorio(PostgresContext contextFactory, IOptions<AppSettings> appSettings)
    : Repository<PostgresContext, Usuario>(contextFactory, appSettings), IUsuariosRepositorio
{
    private DtoUser _user;
    public void SetUser(DtoUser user) => _user = user;
    public DtoUser GetUser() => _user;

    public async Task<Usuario> ObtenerUsuarioCredenciales(string username, string password, CancellationToken cancellationToken = default)
        => await base.GetFirst(b => b.Login == username && b.Contraseña == password, cancellationToken);

    public async Task<Usuario> CrearUsuario(Usuario usuario, CancellationToken cancellationToken = default)
        => await base.AddAsync(usuario, cancellationToken);

    public async Task<List<DtoUsuario>> GetUsuarios(CancellationToken cancellationToken)
    {
        var user = GetUser();
        if (user.IdRol != _appSettings.Roles.Administrador) throw new InvalidOperationException("No tiene permiso para realizar esta tarea");

        var usuarios = (await base.Get(b => true, cancellationToken)).ToList();
        List<DtoUsuario> dtoUsuarios = new();
        foreach (var usuario in usuarios)
            dtoUsuarios.Add(new DtoUsuario(usuario)
            {
                Rol = usuario.RoleId == 1 ? "Administrador" : usuario.RoleId == 2 ? "Compras" : "Ventas"
            });

        return dtoUsuarios;
    }
}