using Microsoft.EntityFrameworkCore;

namespace ControlInventario.Core.Repositorios.Interfaces;
internal interface IRepository<TContext, TEntity>
    where TContext : DbContext
    where TEntity : class { }