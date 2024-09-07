using POSWebApp.Models.ViewModels;

namespace POSWebApp.Services;

public interface IProductService
{
    void Create(ProductViewModel productvm);
    IEnumerable<ProductViewModel> GetAll();
    ProductViewModel GetById(string id);
    void Update(ProductViewModel productvm);
    bool Delete(string id);
}
