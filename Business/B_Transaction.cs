using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Responses;


namespace Business
{
    public class B_Transaction
    {
        
        /// <summary>
        /// Function to execute a sale 
        /// </summary>
        /// <param name="transaction">Sale data</param>
        public static Response ExecuteSale(Transaction transaction)
        {
            Response response = new Response() { Current_Balance = new Current_Balance(), Bussines_Errors = new List<Business_Error>()};
            Account account = B_Account.SearchAccountById(transaction.Id);
            if (account != null)
            {
                Issuer issuer = B_Issuer.SearchAccountByName(account.Issuers, transaction.Issuer_Name);
                if (issuer != null)
                {
                    if (B_Issuer.CheckStock(issuer, transaction.Total_Shares))
                    {
                        issuer.Total_Shares -= transaction.Total_Shares;
                        account.Cash += transaction.Total_Shares * transaction.Shares_Prices;
                        B_Issuer.UpdateIssuer(issuer);
                        B_Account.UpdateAccount(account);
                    }
                    else 
                    { 
                        //Error
                    }
                }
                else
                {
                    //Error
                }
            }
            else
            {
                //Error
            }
            return response;

        }
        /// <summary>
        /// Function to excute a purchase
        /// </summary>
        /// <param name="transaction">Purchase data</param>
        public static Response ExecutePurchase(Transaction transaction)
        {
            Response response = new Response() { Current_Balance = new Current_Balance(), Bussines_Errors = new List<Business_Error>() };
            Current_Balance currentBalance = new Current_Balance();
            Business_Error businessError = new Business_Error();
            Account account = B_Account.SearchAccountById(transaction.Id);
            int total = transaction.Total_Shares * transaction.Shares_Prices;
            if (B_Account.CheckBalance(account, total))
            {
                Issuer issuer = B_Issuer.SearchAccountByName(account.Issuers, transaction.Issuer_Name);
                if (issuer == null)
                {
                    account.Issuers.Add(new Issuer() { Issuer_Name = transaction.Issuer_Name, Account = account, Total_Shares = 0 });
                }
                issuer.Total_Shares += transaction.Total_Shares;
                account.Cash -= total;
                B_Issuer.UpdateIssuer(issuer);
                B_Account.UpdateAccount(account);
            }
            else
            {
                //Error
            }
            return response;
        }


    }
}
