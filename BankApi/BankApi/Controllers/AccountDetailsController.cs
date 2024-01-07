using BankApi.InMemoryDatabase;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;

namespace BankApi.Controllers
{
    public class AccountDetailsController
    {
        [Route("/account-details")]
        public JsonResult GetAccountDetails()
        {
            return new JsonResult(Accounts.GetAccountDetails());
        }
    }
}
