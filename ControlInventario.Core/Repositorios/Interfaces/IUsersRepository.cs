using ControlInventario.Datos.DTO;

namespace ControlInventario.Core.Repositories.Interfaces;
public interface IUsersRepository
{
    void SetUser(DtoUser user);
}