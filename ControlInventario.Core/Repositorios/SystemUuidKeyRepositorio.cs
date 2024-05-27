using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Repositorios;
using ControlInventario.Core.Helpers;
using Microsoft.Extensions.Options;
using ControlInventario.Core.Repositorios.Interfaces;

namespace ControlInventario.Core.Repositories;

public class SystemUuidKeyRepositorio(PostgresContext contextFactory, IOptions<AppSettings> appSettings)
    : Repository<PostgresContext, SystemUuidKey>(contextFactory, appSettings), ISystemUuidRepositorio
{
    public async Task<SystemUuidKey> GetSystemUuidKeyAsync(CancellationToken cancellationToken)
        => await base.GetFirst() ?? throw new InvalidOperationException("No se a encontrado la llave en el sistema, consulte al proveedor del Software");
}