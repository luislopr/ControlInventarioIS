namespace ControlInventario.Core.Repositorios;
public class BaseRepository //: IBaseRepository
{
    //private readonly DbContext _context;
    public BaseRepository(/*DbContext context*/)
    {
        //_context = context;
    }

    public async Task SaveChangeAsync(CancellationToken cancellation, int contador = 0)
    {
       /* try { await _context.SaveChangesAsync(cancellation); }
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
        }*/
    }
}