using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class B_Issuer
    {
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
