using ControlInventario.Datos.ControlInventarioObjects;

namespace ControlInventario.Core.Repositorios.Interfaces;
public interface ISystemUuidRepositorio
{
    Task<SystemConfig> GetSystemUuidKeyAsync(CancellationToken cancellationToken);
}