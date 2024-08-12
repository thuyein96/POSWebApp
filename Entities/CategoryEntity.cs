using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApp.Entities
{
    [Table("Category")]
    public class CategoryEntity : BaseEntity
    {
        public string CategoryName { get; set; }
    }
}
