using Microsoft.AspNetCore.Mvc;

namespace OrdersApi.Controllers
{
    public class HomeController
    {
        [HttpGet("/")]
        public string Welcome()
        {
            return "Welcome to the orders api!";
        }
    }
}
