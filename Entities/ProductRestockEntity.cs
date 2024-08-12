using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Entities;

[Table("ProductRestock")]
public class ProductRestockEntity : BaseEntity
{
    public string ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual ProductEntity Product { get; set; }
    public int RestockQuantity { get; set; }
    public DateTime RestockDate { get; set; }
    
}
