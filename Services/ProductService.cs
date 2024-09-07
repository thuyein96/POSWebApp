using POSWebApp.Models.Entities;
using POSWebApp.Models.ViewModels;
using POSWebApp.UnitOfWork;

namespace POSWebApp.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(ProductViewModel productvm)
    {
        var product = new ProductEntity()
        {
            Id = Guid.NewGuid().ToString(),
            ProductName = productvm.ProductName,
            Description = productvm.Description,
            PurchasePrice = productvm.PurchasePrice,
            SalesPrice = productvm.SalesPrice,
            CategoryId = productvm.CategoryId,
            CreatedAt = DateTime.Now
        };
        _unitOfWork.ProductRepository.Create(product);
        _unitOfWork.Commit();
    }

    public bool Delete(string id)
    {
        try
        {
            var product = _unitOfWork.ProductRepository.GetBy(x => x.Id == id).SingleOrDefault();
            if (product != null)
            {
                product.IsInActive = true;
                _unitOfWork.ProductRepository.Delete(product);
                _unitOfWork.Commit();
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    public IEnumerable<ProductViewModel> GetAll()
    {
        return (from p in _unitOfWork.ProductRepository.GetAll()
                where !p.IsInActive
                select new ProductViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    SalesPrice = p.SalesPrice,
                    PurchasePrice = p.PurchasePrice,
                    CategoryId = p.CategoryId,
                    Category = _unitOfWork.CategoryRepository.GetBy(r => r.Id == p.CategoryId).FirstOrDefault().CategoryName
                }).ToList();
    }

    public ProductViewModel GetById(string id)
    {
        return _unitOfWork.ProductRepository
            .GetBy(w => w.Id == id && !w.IsInActive)
            .Select(p => new ProductViewModel
            {
            Id = p.Id,
            ProductName = p.ProductName,
            Description = p.Description,
            SalesPrice = p.SalesPrice,
            PurchasePrice = p.PurchasePrice,
            CategoryId = p.CategoryId,
            Category = _unitOfWork.CategoryRepository.GetBy(r => r.Id == p.CategoryId).FirstOrDefault().CategoryName
        }).FirstOrDefault();
    }

    public void Update(ProductViewModel productvm)
    {
        var product = new ProductEntity()
        {
            Id = productvm.Id,
            ProductName = productvm.ProductName,
            Description = productvm.Description,
            PurchasePrice = productvm.PurchasePrice,
            SalesPrice = productvm.SalesPrice,
            CategoryId = productvm.CategoryId,
            ModifiedAt = DateTime.Now,
            CreatedAt = productvm.CreatedOn
        };
        _unitOfWork.ProductRepository.Update(product);
        _unitOfWork.Commit();
    }
}
