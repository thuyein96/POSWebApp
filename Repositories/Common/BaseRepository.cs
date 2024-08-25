using Microsoft.EntityFrameworkCore;
using POSWebApp.DTO;
using System.Linq.Expressions;

namespace POSWebApp.Repositories.Common;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly POSWebAppDbContext _posWebAppDbContext;
    private readonly DbSet<T> _dbSet;

   public BaseRepository(POSWebAppDbContext posWebAppDbContext)
    {
        _posWebAppDbContext = posWebAppDbContext;
        _dbSet = _posWebAppDbContext.Set<T>();
    }

    public void Create(T entity)
    {
        _posWebAppDbContext.Add<T>(entity);
    }

    public void Delete(T entity)
    {
        _posWebAppDbContext.Update<T>(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsEnumerable();
    }

    public IEnumerable<T> GetBy(Expression<Func<T, bool>> expression)
    {
        return _dbSet.AsNoTracking().Where(expression).AsEnumerable();
    }

    public void Update(T entity)
    {
        _posWebAppDbContext.Update<T>(entity);
    }
}
