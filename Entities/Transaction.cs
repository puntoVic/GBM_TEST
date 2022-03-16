using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdTransaction { get; set;}
        public string Timestamp { get; set; }
        public string TypeOperation { get; set;  }
        public string Issuer_Name { get; set; }
        public Issuer Issuer { get; set; }
        public int Total_Shares { get; set; }
        public int Shares_Prices { get; set; }
        
        public int Id { get; set; }
        public Account Account { get; set; }


    }
}
