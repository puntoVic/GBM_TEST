using System;
using Xunit;
using API_TestGBM.Controllers;
using Entities;
using Entities.Responses;
using Business;

namespace API_GBM_Test
{

    public class TransactionTest
    {
        private readonly TransactionController _transactionController = new TransactionController();
        Transaction transactionRightPurchase = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "BUY",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = 50,
            AccountId = 2
        };

        
        [Fact]
        public void IsAValidOkPurchaseResponse()
        {
            Response response = _transactionController.Transaction(transactionRightPurchase);

            Assert.True(B_Transaction.IsValidResponse(response));
        }
        
        
        //[Fact]
        //public void IsAValidOkSaleResponse()
        //{
        //    Account account = new Account() { Cash = 60000 };

        //    _accountController.Post(account);

        //    Assert.True(B_Account.IsValidAccount(account));
        //}
        
    }
}
