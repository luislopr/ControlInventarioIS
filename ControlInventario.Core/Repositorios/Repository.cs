using ControlInventario.Core.Helpers;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Core.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace ControlInventario.Core.Repositorios;
public abstract class Repository<TContext, TEntity> : IRepository<TContext, TEntity> where TContext : DbContext where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _table;
    protected readonly AppSettings _appSettings;
    protected readonly IAuthRepository _usersRepository;

    public Repository(TContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public Repository(TContext context, IOptions<AppSettings> options)
    {
        _context = context;
        _table = _context.Set<TEntity>();
        this._appSettings = options.Value;
    }

    public Repository(TContext context, IOptions<AppSettings> options, IAuthRepository usersRepository)
    {
        _context = context;
        _table = _context.Set<TEntity>();
        this._appSettings = options.Value;
        this._usersRepository = usersRepository;
    }
    public async Task SaveChangeAsync(CancellationToken cancellation, int contador = 0)
    {
        try { await _context.SaveChangesAsync(cancellation); }
        catch
        {
            if (contador < 2)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                await SaveChangeAsync(cancellation, contador + 1);
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<IEnumerable<TEntity>> GetAll() => await _table.ToListAsync();
    public async Task<IEnumerable<TEntity>> GetAllNoTracking() => await _table.AsNoTracking().ToListAsync();
    public async Task<TEntity?> GetFirst() => await _table.AsNoTracking().FirstOrDefaultAsync();

    public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> where, CancellationToken cancellation)
        => await _table.Where(where).ToListAsync(cancellation);
    public async Task<TEntity?> GetFirst(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken)
        => await _table.Where(where).FirstOrDefaultAsync(cancellationToken);

    public async Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellation)
    {
        var retval = await _table.AddAsync(obj, cancellation);
        await SaveChangeAsync(cancellation);
        return retval.Entity;
    }

    public async Task AddManyAsync(IEnumerable<TEntity> obj, CancellationToken cancellationToken)
    {
        try
        {
            await _table.AddRangeAsync(obj);
            await SaveChangeAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw new InvalidOperationException("No se han podido guardar los datos");
        }
    }

    public async Task UpdateAsync(TEntity obj, CancellationToken cancellation)
    {
        _table.Attach(obj);
        await SaveChangeAsync(cancellation);
    }

    public async Task Remove(TEntity obj, CancellationToken cancellation)
    {
        _table.Remove(obj);
        await SaveChangeAsync(cancellation);
    }

    public async Task<TEntity?> GetById(int id) => await this._table.FindAsync(id);
}