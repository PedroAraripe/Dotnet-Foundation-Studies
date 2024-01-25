using Microsoft.AspNetCore.Mvc;
using OrdersApi.Models;

namespace OrdersApi.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost("/order")]
        public IActionResult CreateOrderController([FromBody] Order Order)
        {
            if(!ModelState.IsValid)
            {
                IEnumerable<string> errorsList = ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage);
                string errors = string.Join("\n", errorsList);

                return BadRequest(errors);
            }
            else
            {
                return Order.CreateOrder();
            }
        }
    }
}
