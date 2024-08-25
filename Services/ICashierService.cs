using POSWebApp.Models.ViewModels;

namespace POSWebApp.Services;

public interface ICashierService
{
    void Create(CashierViewModel cashiervm);
    IEnumerable<CashierViewModel> GetAll();
    CashierViewModel GetById(string id);
    void Update(CashierViewModel cashiervm);
    bool Delete(string id);
}
