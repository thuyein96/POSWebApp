using POSWebApp.DTO;
using POSWebApp.Models.Entities;
using POSWebApp.Repositories.Common;

namespace POSWebApp.Repositories.Domain;

public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
{
    private readonly POSWebAppDbContext _posWebAppDbContext;

    public CategoryRepository(POSWebAppDbContext posWebAppDbContext) : base(posWebAppDbContext)
    {
        _posWebAppDbContext = posWebAppDbContext;
    }
}
