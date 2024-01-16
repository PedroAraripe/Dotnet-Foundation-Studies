using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;

namespace OrdersApi.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost("/order")]
        async public Task<string> CreateOrderController()
        {
            StreamReader reader = new StreamReader(Request.Body);
            string body = await reader.ReadToEndAsync();
            Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

            return $"salve {queryDict["OrderDate"]} {System.Guid.NewGuid()}";
        }
    }
}
