using ControlInventario.Datos.ControlInventarioObjects;

namespace ControlInventario.Core.Repositorios.Interfaces;
public interface ISystemUuidRepositorio
{
    Task<SystemUuidKey> GetSystemUuidKeyAsync(CancellationToken cancellationToken);
}