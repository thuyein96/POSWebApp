using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities;

[Table("Product")]
public class ProductEntity : BaseEntity
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalesPrice { get; set; }
    public string CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual CategoryEntity Category { get; set; }
}
