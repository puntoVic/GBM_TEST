using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Current_Balance
    {
        public int Cash { get; set; }
        public List<Issuer> Stocks { get; set; }

        public Current_Balance()
        {
            Stocks = new List<Issuer>();
        }

    }
}
