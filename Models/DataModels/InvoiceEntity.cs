using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities;

[Table("Invoice")]
public class InvoiceEntity : BaseEntity
{
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string TransactionId { get; set; }
    [ForeignKey("TransactionId")]
    public virtual TransactionEntity Transaction { get; set; }
}
