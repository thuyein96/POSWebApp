using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities;

[Table("ProductBalance")]
public class ProductBalanceEntity : BaseEntity
{
    public string ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual ProductEntity Product { get; set; }
    public int ProductQuantity { get; set; }
}
