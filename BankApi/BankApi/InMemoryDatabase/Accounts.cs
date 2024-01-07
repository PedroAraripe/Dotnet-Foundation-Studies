using Microsoft.AspNetCore.Mvc;

namespace BankApi.InMemoryDatabase
{
    public class Accounts
    {
        static public Dictionary<string, string> accountsDetails = new Dictionary<string, string>()
        {
            {
                "accountNumber", "1001"
            },
            {
                "accountHolderName", "Example Name"
            },
            {
                "currentBalance", "5000"
            }
        };

        static public Dictionary<string, string> GetAccountDetails()
        {
            return accountsDetails;

        }
        static public VirtualFileResult GetAccountStatement()
        {
            return new VirtualFileResult("/dummyPdf.pdf", "application/pdf");

        }
        static public int? GetAccountCurrentBalance(int accountNumber)
        {
            if(accountNumber == Convert.ToInt16(accountsDetails["accountNumber"]))
            {
                return Convert.ToInt16(accountsDetails["currentBalance"]);
            }

            return null;
        }
    }
}
