using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScruffyNerfHerderSabers.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int ProductID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string ProductName { get; set; }
        public int UPC { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public string Color { get; set; }
        public string Hilt { get; set; }
        public string Hand { get; set; }

        public int DepartmentID { get; set; }


        public virtual Department Department { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}