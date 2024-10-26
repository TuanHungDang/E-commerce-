using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

public class CartController : BaseController
{
    const string cart = "cart";

    VnPaymentService vnPayment;
    public CartController(VnPaymentService vnPayment)
    {
        this.vnPayment = vnPayment;
    }

    public IActionResult VnPaymentResponse(VnPaymentResponse obj)
    {
        int ret = Provider.VnPayment.Add(obj);
        if(ret > 0){
            TempData["Msg"]="Checkout Success";
            return Redirect("/cart/success");
        }
        return Redirect("/cart/error");
    }

    public IActionResult Success(){
        return View();
    }

    public IActionResult Checkout()
    {
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            return Redirect("/");
        }
        return View(Provider.Cart.GetCarts(code));
    }
    [HttpPost]
    public IActionResult Checkout(Invoice obj)
    {
        // Retrieve the cart code from the cookies
        string? code = Request.Cookies["cart"];

        // If the cart code is null or empty, redirect to home page
        if (string.IsNullOrEmpty(code))
        {
            return Redirect("/");
        }

        // Generate a random InvoiceId
        Random random = new Random();
        obj.InvoiceId = random.NextInt64(9999999, 9999999999999);

        // Set the CartCode from the retrieved code
        obj.CartCode = code;

        // Set the InvoiceDate to the current date and time
        obj.InvoiceDate = DateTime.Now;

        // Call the provider to add the invoice and get the result
        int result = Provider.Invoice.Add(obj);

        // If the result is successful, redirect to success page
        if (result > 0)
        {
            obj.Amount = Provider.Invoice.GetAmountInvoice(obj.InvoiceId) * 1000;
            string url = vnPayment.ToUrl(obj);
            return Redirect(url);
            //return Redirect("/cart/success");
        }

        // If failed, redirect to error page
        return Redirect("/cart/error");
    }

    public IActionResult Index()
    {
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            return Redirect("/");
        }

        return View(Provider.Cart.GetCarts(code));
    }

    [HttpPost]

    public IActionResult Edit(Cart obj)
    {
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            return Redirect("/");
        }
        obj.CartCode = code;
        return Json(Provider.Cart.Edit(obj));
    }

    [HttpPost]
    public IActionResult Add(Cart obj)
    {
        //Cookies
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            code = Guid.NewGuid().ToString().Replace("-", "");
            Response.Cookies.Append(cart, code);
        }
        obj.CartCode = code;
        int ret = Provider.Cart.Add(obj);
        if (ret > 0)
        {
            return Redirect("/cart");
        }

        return Redirect("/cart/error");
    }

    public IActionResult Delete(int id)
    {
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            code = Guid.NewGuid().ToString().Replace("-", "");
            Response.Cookies.Append(cart, code);
        }
        int ret = Provider.Cart.Delete(code, id);
        if (ret > 0)
        {
            return Redirect("/cart");
        }

        return Redirect("/cart/error");
    }
}