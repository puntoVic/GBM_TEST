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
                Issuer issuer = B_Issuer.SearchIssuerByName(account.Issuers, transaction.Issuer_Name);
                if (issuer != null)
                {
                    if (B_Issuer.CheckStock(issuer, transaction.Total_Shares))
                    {
                        issuer.Total_Shares -= transaction.Total_Shares;
                        account.Cash += transaction.Total_Shares * transaction.Shares_Prices;
                        response = GenerateSuccessResponse(issuer, account);
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
            int total = transaction.Total_Shares * transaction.Shares_Prices;
            Account account = B_Account.SearchAccountById(transaction.Id);
            if (B_Account.CheckBalance(account, total))
            {
                Issuer issuer = B_Issuer.SearchIssuerByName(account.Issuers, transaction.Issuer_Name);
                if (issuer == null)
                {
                    account.Issuers.Add(new Issuer() { Issuer_Name = transaction.Issuer_Name, Account = account, Total_Shares = 0 });
                }
                issuer.Total_Shares += transaction.Total_Shares;
                account.Cash -= total;
                response = GenerateSuccessResponse(issuer, account);
            }
            else
            {
                //Error
            }
            return response;
        }

        private static Response GenerateSuccessResponse(Issuer issuer, Account account)
        {
            Response response = new Response() { Current_Balance = new Current_Balance(), Bussines_Errors = new List<Business_Error>() };
            B_Issuer.UpdateIssuer(issuer);
            B_Account.UpdateAccount(account);
            response.Current_Balance.Cash = account.Cash;
            response.Current_Balance.Stocks = account.Issuers;
            return response;
        }


    }
}
