using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScruffyNerfHerderSabers.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Rank { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}