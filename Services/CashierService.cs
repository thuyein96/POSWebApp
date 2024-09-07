using POSWebApp.Models.Entities;
using POSWebApp.Models.ViewModels;
using POSWebApp.Repositories.Domain;
using POSWebApp.UnitOfWork;

namespace POSWebApp.Services;

public class CashierService : ICashierService
{
    private readonly IUnitOfWork _unitOfWork;

    public CashierService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CashierViewModel cashiervm)
    {
        var cashier = new CashierEntity()
        {
            Id = Guid.NewGuid().ToString(),
            CashierName = cashiervm.Name,
            Gender = cashiervm.Gender,
            BirthDate = cashiervm.BirthDate,
            DOE = cashiervm.DOE,
            DOR = cashiervm.DOR,
            Address = cashiervm.Address,
            Salary = cashiervm.Salary,
            Phone = cashiervm.Phone,
            CreatedAt = DateTime.Now
        };
        _unitOfWork.CashierRepository.Create(cashier);
        _unitOfWork.Commit();
    }

    public bool Delete(string id)
    {
        try
        {
            var entity = _unitOfWork.CashierRepository.GetBy(x => x.Id == id).SingleOrDefault();
            if (entity != null)
            {
                entity.IsInActive = true;
                _unitOfWork.CashierRepository.Delete(entity);
                _unitOfWork.Commit();
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    public IEnumerable<CashierViewModel> GetAll()
    {
        return (from e in _unitOfWork.CashierRepository.GetAll()
                where !e.IsInActive
                select new CashierViewModel
                {
                    Id = e.Id,
                    Name = e.CashierName,
                    Gender = e.Gender,
                    BirthDate = e.BirthDate,
                    DOE = e.DOE,
                    DOR = e.DOR,
                    Address = e.Address,
                    Salary = e.Salary,
                    Phone = e.Phone,
                    CreatedOn = e.CreatedAt
                }).ToList();
    }

    public CashierViewModel GetById(string id)
    {
        return _unitOfWork.CashierRepository.GetBy(w => w.Id == id && !w.IsInActive).Select(c => new CashierViewModel
        {
            Id = c.Id,
            Name = c.CashierName,
            Gender = c.Gender,
            BirthDate = c.BirthDate,
            DOE = c.DOE,
            DOR = c.DOR,
            Address = c.Address,
            Salary = c.Salary,
            Phone = c.Phone,
        }).FirstOrDefault();
    }

    public void Update(CashierViewModel cashiervm)
    {
        var cashier = new CashierEntity()
        {
            Id = cashiervm.Id,
            CashierName = cashiervm.Name,
            Gender = cashiervm.Gender,
            BirthDate = cashiervm.BirthDate,
            DOE = cashiervm.DOE,
            DOR = cashiervm.DOR,
            Address = cashiervm.Address,
            Salary = cashiervm.Salary,
            Phone = cashiervm.Phone,
            ModifiedAt = DateTime.Now,
            CreatedAt = cashiervm.CreatedOn
        };
        _unitOfWork.CashierRepository.Update(cashier);
        _unitOfWork.Commit();
    }
}
