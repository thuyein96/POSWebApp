using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities;

[Table("TransactionDetail")]
public class TransactionDetailEntity : BaseEntity
{
    public string ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual ProductEntity Product { get; set; }

    public string TransactionId { get; set; }
    [ForeignKey("TransactionId")]
    public virtual TransactionEntity Transaction { get; set; }

    public int Quantity { get; set; }
}
