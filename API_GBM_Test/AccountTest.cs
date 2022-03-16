using System;
using Xunit;
using API_TestGBM.Controllers;
using Entities;
using Business;

namespace API_GBM_Test
{
    public class AccountTest
    {
        private readonly AccountController _accountController = new AccountController();
        [Fact]
        public void ResponseIsAnAccount()
        {
            Account account = new Account() { Cash = 60000 };

            Account response = _accountController.Post(account);

            Assert.True(response != null && Object.ReferenceEquals(response.GetType(), account.GetType()));
        }
        [Fact]
        public void ResponseIsAValidAccount()
        {
            Account account = new Account() { Cash = 60000 };
            
            _accountController.Post(account);

            Assert.True(B_Account.IsValidAccount(account));
           

        }
        [Fact]
        public void ResponseIsRightAccount()
        {
            Account account = new Account() { Cash = 60000 };

            _accountController.Post(account);

            Assert.True(B_Account.IsValidAccount(account) && account.Cash == 60000);


        }
    }
}
