using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Entities;

public class ProductRestockEntity : BaseEntity
{
    public string ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual ProductEntity Product { get; set; }
    public int RestockQuantity { get; set; }
    public DateTime RestockDate { get; set; }
    
}
