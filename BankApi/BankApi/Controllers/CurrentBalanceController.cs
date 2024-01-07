using BankApi.InMemoryDatabase;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    public class CurrentBalanceController : Controller
    {
        [Route("current-balance/{accountNumber:int}")]
        public string CurrentBalance ()
        {
            int accountNumber = Convert.ToInt16(Request.RouteValues["accountNumber"]);
            int? accountBalance = Accounts.GetAccountCurrentBalance(accountNumber);
            string supposedAccountNumber = Accounts.GetAccountDetails()["accountNumber"];

            if (accountBalance == null)
            {
                Response.StatusCode = 400;
                return $"Account Number should be {supposedAccountNumber}";
            }
            else
            {
                return $"{accountBalance}";
            }
        }
        [Route("current-balance/")]
        public string CurrentBalanceWithoutAccountNumber()
        {
            ControllerContext.HttpContext.Response.StatusCode = 404;
            return "Account Number should be supplied";
        }

    }
}
