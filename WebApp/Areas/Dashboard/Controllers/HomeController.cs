using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Controllers;

[Area("dashboard")]


public class HomeController : BaseController
{
    public IActionResult Index(){
        ViewBag.CategoryProduct = Provider.Category.GetCategoryAndProducts();
        IEnumerable<SalesByAge> list = Provider.Invoice.GetSalesByAge();
        ViewBag.MinMax = new{
            AgeMin = list.Min(p => p.Age),
            AgeMax = list.Max(p => p.Age),
            SalesMin = list.Min(p => p.Sales),
            SalesMax = list.Max(p => p.Sales)
        };
        ViewBag.GetSalesByAge = list;

        ViewBag.Employee = Provider.Employee.GetEmployeesAndParent();
        ViewBag.SalesAndExpenses = Provider.SalesAndExpenses.GetSalesAndExpenses();
        return View();
    }
}
