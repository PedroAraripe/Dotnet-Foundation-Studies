using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    public class HomeController
    {
        [Route("/")]
        public string GetHomeController()
        {
            return "Welcome to the Best Bank";
        }
    }
}
