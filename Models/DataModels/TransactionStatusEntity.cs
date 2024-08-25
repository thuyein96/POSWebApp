using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities;

[Table("TransactionStatus")]
public class TransactionStatusEntity : BaseEntity
{
    public string Status { get; set; }
}
