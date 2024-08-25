using POSWebApp.DTO;
using POSWebApp.Models.Entities;
using POSWebApp.Repositories.Common;
using System.Linq.Expressions;

namespace POSWebApp.Repositories.Domain;

public class CashierRepository : BaseRepository<CashierEntity>, ICashierRepository
{
    private readonly POSWebAppDbContext _posWebAppDbContext;
    public CashierRepository(POSWebAppDbContext posWebAppDbContext) : base(posWebAppDbContext)
    {
        _posWebAppDbContext = posWebAppDbContext;
    }
}
