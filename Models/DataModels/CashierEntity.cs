using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities;

[Table("Cashier")]
public class CashierEntity : BaseEntity
{
    public string CashierName { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime DOE { get; set; }
    public DateTime? DOR { get; set; }
    public string? Address { get; set; }
    public decimal Salary { get; set; }
    public string? Phone { get; set; }
    public string UserId { get; set; }
}
