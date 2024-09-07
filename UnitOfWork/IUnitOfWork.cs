using POSWebApp.Repositories.Domain;

namespace POSWebApp.UnitOfWork;

public interface IUnitOfWork
{
    ICashierRepository CashierRepository { get; }
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    void Commit();
    void Roolback();
}
