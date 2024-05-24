using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Core.Repositorios;
using ControlInventario.Core.Helpers;
using Microsoft.Extensions.Options;
using ControlInventario.Datos.DTO;

namespace ControlInventario.Core.Repositories;

public class UsersRepository(PostgresContext contextFactory, IOptions<AppSettings> appSettings)
    : Repository<PostgresContext, Usuario>(contextFactory, appSettings), IUsersRepository
{
    private DtoUser _user;
    public void SetUser(DtoUser user) => _user = user;
    public DtoUser GetUser() => _user;
}