using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSWebApp.Models.ViewModels;
using POSWebApp.Services;

namespace POSWebApp.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService,
                             ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Entry() => View();

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult Entry(ProductViewModel productvm)
    {
        try
        {
            _productService.Create(productvm);
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

    public IActionResult List() => View(_productService.GetAll());

    [Authorize(Roles = "Admin")]
    public IActionResult Edit(string id)
    {
        ProductViewModel productvm = _productService.GetById(id);
        return View(productvm);
    }

    [HttpPost]
    public IActionResult Update(ProductViewModel productvm)
    {
        try
        {
            _productService.Update(productvm);
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
            _productService.Delete(id);
            TempData["Info"] = "Delete Successfully";
        }
        catch (Exception e)
        {
            TempData["Info"] = "Error occur when delete the record." + e.Message;
        }
        return RedirectToAction("List");
    }
}
