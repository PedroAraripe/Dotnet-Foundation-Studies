using BankApi.InMemoryDatabase;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    public class AccountStatementController
    {
        [Route("/account-statement/")]
        public VirtualFileResult GetAccountStatement()
        {
            return Accounts.GetAccountStatement();
        }
    }
}
