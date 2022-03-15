using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Market
    {
        [Key]
        public string MarketId { get; set;  }
        public ICollection<Issuer> Issuers { get; set; }
    }
}
