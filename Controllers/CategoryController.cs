using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSWebApp.Models.ViewModels;
using POSWebApp.Services;

namespace POSWebApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Entry() => View();

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult Entry(CategoryViewModel categoryvm)
    {
        try
        {
            _categoryService.Create(categoryvm);
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

    public IActionResult List() => View(_categoryService.GetAll());

    [Authorize(Roles = "Admin")]
    public IActionResult Edit(string id)
    {
        var categoryvm = _categoryService.GetById(id);
        return View(categoryvm);
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public IActionResult Update(CategoryViewModel categoryvm)
    {
        try
        {
            _categoryService.Update(categoryvm);
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
            _categoryService.Delete(id);
            TempData["Info"] = "Delete Successfully";
        }
        catch (Exception e)
        {
            TempData["Info"] = "Error occur when delete the record." + e.Message;
        }
        return RedirectToAction("List");
    }
}
