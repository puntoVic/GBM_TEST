using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;

namespace Business
{
    public class B_Issuer
    {
        /// <summary>
        /// Initial function to create an issuer 
        /// </summary>
        /// <param name="issuer">Issuer to create</param>
        /// <returns></returns>
        public static int CeateIssuer(Issuer issuer)
        {
            using (var db = new Context())
            {
                db.Issuers.Add(issuer);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// Function for search in db an issuer by its issuer name
        /// </summary>
        /// <param name="issuers">Issuers List to find </param
        /// <param name="issuer_name">Issuer name</param>
        /// <returns></returns>
        public static Issuer SearchAccountByName(List<Issuer> issuers, string issuer_name)
        {
           
            return issuers.Find(x => x.Issuer_Name == issuer_name);
           
        }
        /// <summary>
        /// Function for update an issuer
        /// </summary>
        /// <param name="issuer">Issuer to update</param>
        public static void UpdateAccount(Issuer issuer)
        {
            using (var db = new Context())
            {
                db.Issuers.Update(issuer);

            }
        }
        /// <summary>
        /// function to chek real stock of an account before selling
        /// </summary>
        /// <param name="issuer">stock to check</param>
        /// <param name="shares">Total shares to selling</param>
        /// <returns></returns>
        public static bool CheckStock(Issuer issuer, int shares)
        {
            return issuer.Total_Shares > shares;
        }
    }
}
