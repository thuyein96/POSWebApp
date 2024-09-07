using POSWebApp.Models.ViewModels;

namespace POSWebApp.Services;

public interface ICategoryService
{
    void Create(CategoryViewModel categoryvm);
    IEnumerable<CategoryViewModel> GetAll();
    CategoryViewModel GetById(string id);
    void Update(CategoryViewModel categoryvm);
    bool Delete(string id);
}
