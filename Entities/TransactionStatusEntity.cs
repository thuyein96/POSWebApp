using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Entities;

[Table("TransactionStatus")]
public class TransactionStatusEntity : BaseEntity
{
    public string Status { get; set; }
}
