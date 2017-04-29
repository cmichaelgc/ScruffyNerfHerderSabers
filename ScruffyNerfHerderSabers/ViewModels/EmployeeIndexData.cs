using System;
using System.Collections.Generic;
using ScruffyNerfHerderSabers.Models;
using System.Linq;
using System.Web;

namespace ScruffyNerfHerderSabers.ViewModels
{
    public class EmployeeIndexData
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}