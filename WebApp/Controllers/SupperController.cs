using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class SupplierController : BaseController
{
    public IActionResult Index()
    {
        ViewBag.Supplieres = Provider.Supplier.GetSupplieres();
        return View(Provider.Supplier.GetSupplieres());
    }

    public IActionResult Details(string id)
    {
        ViewBag.Supplieres = Provider.Supplier.GetSupplieres();
        ViewBag.Supplier = Provider.Supplier.GetSupplier(id);
        return View();
    }
}
