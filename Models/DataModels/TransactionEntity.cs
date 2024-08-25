using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities;

[Table("Transaction")]
public class TransactionEntity : BaseEntity
{
    public DateTime TransactionDate { get; set; }
    public string TransactionStatusId { get; set; }
    [ForeignKey("TransactionStatusId")]
    public virtual TransactionStatusEntity TransactionStatus { get; set; }
    public string CashierId { get; set; }
    [ForeignKey("CashierId")]
    public virtual CashierEntity Cashier { get; set; }
}
