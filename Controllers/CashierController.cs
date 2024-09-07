using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSWebApp.Models.ViewModels;
using POSWebApp.Services;

namespace POSWebApp.Controllers
{
    public class CashierController : Controller
    {
        private readonly ICashierService _cashierService;

        public CashierController(ICashierService cashierService)
        {
            _cashierService = cashierService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Entry() => View();
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Entry(CashierViewModel cashiervm)
        {
            try
            {
                _cashierService.Create(cashiervm);
                ViewData["Info"] = "Successfully save the record to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the record save to the system." + e.Message;
                ViewData["Status"] = false;
            }
            return View();
        }

        public IActionResult List() => View(_cashierService.GetAll());

        public IActionResult Edit(string id)
        {
            CashierViewModel cashierView = _cashierService.GetById(id);
            return View(cashierView);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(CashierViewModel cashierViewModel)
        {
            try
            {
                _cashierService.Update(cashierViewModel);
                TempData["Info"] = "Successfully update the record to the system.";
                TempData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the record update to the system." + e.Message;
                ViewData["Status"] = false;
            }
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                _cashierService.Delete(id);
                TempData["Info"] = "Delete Successfully";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when delete the record." + e.Message;
            }
            return RedirectToAction("List");
        }
    }
}
