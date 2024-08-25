using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Models.Entities
{
    [Table("Category")]
    public class CategoryEntity : BaseEntity
    {
        public string CategoryName { get; set; }
    }
}
