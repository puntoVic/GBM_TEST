using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Current_Balance
    {
        public int Cash { get; set; }
        public List<Issuer> Issuers { get; set; }

        public Current_Balance()
        {
            Issuers = new List<Issuer>();
        }

    }
}
