namespace POSWebApp.Models.ViewModels;

public class CashierViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime DOE { get; set; }
    public DateTime? DOR { get; set; }
    public string? Address { get; set; }
    public decimal Salary { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string UserId { get; set; }
}
