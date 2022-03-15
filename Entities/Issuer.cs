using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Issuer
    {
        [Key]
        [StringLength(10)]
        [Required]
        public string Issuer_Name { get; set; }
        public int Value { get; set; }

        public ICollection<Stock> Stocks { get; set;  }
        public ICollection<Transaction> Transactions { get; set; }
        public string MarketId { get; set; }
        public Market Market { get; set; }
    }
}
