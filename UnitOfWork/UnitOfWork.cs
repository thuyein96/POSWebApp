using POSWebApp.DTO;
using POSWebApp.Repositories.Domain;

namespace POSWebApp.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly POSWebAppDbContext _posWebAppDbContext;

    public UnitOfWork(POSWebAppDbContext posWebAppDbContext)
    {
        _posWebAppDbContext = posWebAppDbContext;
    }

    private ICashierRepository _cashierRepository;
    public ICashierRepository CashierRepository
    {
        get
        {
            return _cashierRepository = _cashierRepository ?? new CashierRepository(_posWebAppDbContext);
        }
    }
    public void Commit()
    {
        _posWebAppDbContext.SaveChanges();
    }

    public void Roolback()
    {
        _posWebAppDbContext.Dispose();
    }
}
