
using ControlInventario.Core.Models;

namespace ControlInventario.Core.Repositories.Interfaces;
public interface IAuthRepository
{
    Task<string> PostAuthAsync(string username, string password, CancellationToken cancellationToken = default);
    Task<string> RegisterAsync(RegisterRequestModel a, CancellationToken cancellationToken);
}