using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using POSWebApp.Entities;

namespace POSWebApp.DTO;

public class POSWebAppDbContext : DbContext
{
    public POSWebAppDbContext(DbContextOptions<POSWebAppDbContext> options) : base(options) {}

    public DbSet<CategoryEntity> CategoryEntities { get; set; }
    public DbSet<ProductEntity> ProductEntities { get; set; }
    public DbSet<ProductRestockEntity> ProductRestockEntities { get; set; }
    public DbSet<ProductBalanceEntity> ProductBalanceEntities { get; set; }
}
