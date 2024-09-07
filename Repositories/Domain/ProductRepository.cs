using POSWebApp.DTO;
using POSWebApp.Models.Entities;
using POSWebApp.Repositories.Common;

namespace POSWebApp.Repositories.Domain;

public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
{
    private readonly POSWebAppDbContext _posWebAppDbContext;
    public ProductRepository(POSWebAppDbContext posWebAppDbContext) : base(posWebAppDbContext)
    {
        _posWebAppDbContext = posWebAppDbContext;
    }
}
