using POSWebApp.Models.Entities;
using POSWebApp.Models.ViewModels;
using POSWebApp.UnitOfWork;

namespace POSWebApp.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CategoryViewModel categoryvm)
    {
        var category = new CategoryEntity()
        {
            Id = Guid.NewGuid().ToString(),
            CategoryName = categoryvm.CategoryName,
            CreatedAt = DateTime.Now
        };
        _unitOfWork.CategoryRepository.Create(category);
        _unitOfWork.Commit();
    }

    public bool Delete(string id)
    {
        try
        {
            var category = _unitOfWork.CategoryRepository.GetBy(x => x.Id == id).SingleOrDefault();
            if (category != null)
            {
                category.IsInActive = true;
                _unitOfWork.CategoryRepository.Delete(category);
                _unitOfWork.Commit();
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    public IEnumerable<CategoryViewModel> GetAll()
    {
        return (from c in _unitOfWork.CategoryRepository.GetAll()
                where !c.IsInActive
                select new CategoryViewModel
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName
                }).ToList();
    }

    public CategoryViewModel GetById(string id)
    {
        return _unitOfWork.CategoryRepository.GetBy(w => w.Id == id && !w.IsInActive).Select(c => new CategoryViewModel
        {
            Id = c.Id,
            CategoryName = c.CategoryName
        }).FirstOrDefault();
    }

    public void Update(CategoryViewModel categoryvm)
    {
        var category = new CategoryEntity()
        {
            Id = categoryvm.Id,
            CategoryName = categoryvm.CategoryName,
            ModifiedAt = DateTime.Now,
            CreatedAt = categoryvm.CreatedOn
        };
        _unitOfWork.CategoryRepository.Update(category);
        _unitOfWork.Commit();
    }
}
