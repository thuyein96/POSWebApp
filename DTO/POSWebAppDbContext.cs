using Microsoft.EntityFrameworkCore;
using POSWebApp.Entities;

namespace POSWebApp.DTO;

public class POSWebAppDbContext : DbContext
{
    public POSWebAppDbContext(DbContextOptions<POSWebAppDbContext> options) : base(options) { }

    public DbSet<CategoryEntity> CategoryEntities { get; set; }
    public DbSet<ProductEntity> ProductEntities { get; set; }
    public DbSet<ProductRestockEntity> ProductRestockEntities { get; set; }
    public DbSet<ProductBalanceEntity> ProductBalanceEntities { get; set; }
    public DbSet<TransactionDetailEntity> TransactionDetailEntities { get; set; }
    public DbSet<TransactionEntity> TransactionEntities { get; set; }
    public DbSet<TransactionStatusEntity> TransactionStatusEntities { get; set; }
    public DbSet<CashierEntity> CashierEntities { get; set; }
    public DbSet<InvoiceEntity> InvoiceEntities { get; set; }
}
