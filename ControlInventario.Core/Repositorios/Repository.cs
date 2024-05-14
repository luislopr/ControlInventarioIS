using System.Linq.Expressions;

namespace ControlInventario.Core.Repositorios;
public abstract class Repository<TContext, TEntity> : BaseRepository //, IRepository<TContext, TEntity> where TContext : DbContext where TEntity : class
{
    //private readonly DbContext _context;
    //private readonly DbSet<TEntity> _table;

    public Repository(TContext context) //: base(context)
    {
        //_context = context;
        //_table = _context.Set<TEntity>();
    }

    //public async Task<IEnumerable<TEntity>> GetAll() => await _table.ToListAsync();
    //public async Task<IEnumerable<TEntity>> GetAllNoTracking() => await _table.AsNoTracking().ToListAsync();
    //public async Task<TEntity?> GetFirst() => await _table.AsNoTracking().FirstOrDefaultAsync();
    /*
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
    }*/
}