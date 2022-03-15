using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string StockId { get; set;  }
        public int Ammount { get; set; }

        public string Issuer_Name { get; set; }
        public Issuer Issuer { get; set; }

        public string Id { get; set; }
        public Account Account { get; set; }
    }
}
