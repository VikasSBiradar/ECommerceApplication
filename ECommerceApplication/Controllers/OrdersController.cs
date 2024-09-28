using ECommerceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.Controllers
{
    public class OrdersController : Controller
    {
        [HttpPost]
        [Route("/order")]
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            if (!ModelState.IsValid)
            {
                string message = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return BadRequest(message);
            }

            Random randon = new Random();
            int randomOrderNumber = randon.Next(1, 99999);
            return Json(new { orderNumber = randomOrderNumber });
        }
    }
}
