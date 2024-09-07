using POSWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.ViewModels;

public class ProductViewModel
{
    public string Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalesPrice { get; set; }
    public string? CategoryId { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
