using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScruffyNerfHerderSabers.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UPC { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public string Color { get; set; }
        public string Hilt { get; set; }
        public string Hand { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}