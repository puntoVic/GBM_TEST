using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;

namespace Business
{
    public class B_Account
    {
        public static int CeateAccount(Account account)
        {
            using (var db = new Context())
            {
                account.Issuers = new List<Stock>();
                db.Accounts.Add(account);
                return db.SaveChanges();
            }
        }

        public static Account SearchAccountById(Int64 id)
        {
            using (var db = new Context())
            {
                return db.Accounts.Find(id);
            }
        }
        public static void UpdateAccount(Account account)
        {
            using (var db = new Context())
            {
                db.Accounts.Update(account);

            }
        }
    }
}
