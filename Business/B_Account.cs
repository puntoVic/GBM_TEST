using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;

namespace Business
{
    public static class B_Account
    {
        /// <summary>
        /// Initial function to create an account 
        /// </summary>
        /// <param name="account">Account to create</param>
        /// <returns></returns>
        public static int CeateAccount(Account account)
        {
            using (var db = new Context())
            {
                try
                {
                    account.Issuers = new List<Issuer>();
                    db.Accounts.Add(account);
                    return db.SaveChanges();
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Function for search an account by its Id in DB
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns></returns>
        public static Account SearchAccountById(Int32 id)
        {
            using (var db = new Context())
            {
                try
                {
                    return db.Accounts.Find(id);
                }
                catch
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Function for update an account
        /// </summary>
        /// <param name="account">Account to update</param>
        public static void UpdateAccount(Account account)
        {
            using (var db = new Context())
            {
                db.Accounts.Update(account);

            }
        }
        /// <summary>
        /// Function for review founds on balance
        /// </summary>
        /// <param name="account">account to review</param>
        /// <param name="totalSharePrice">Ammount total of shares to buy</param>
        /// <returns></returns>
        public static bool CheckBalance(Account account, int totalSharePrice)
        {
            return account.Cash > totalSharePrice;
        }

        public static bool IsValidAccount(Account account)
        {
            return account != null && account.AccountId > 0 && account.Issuers != null;
        }


    }
}
