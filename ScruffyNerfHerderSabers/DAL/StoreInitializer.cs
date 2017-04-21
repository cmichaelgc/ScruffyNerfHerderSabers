using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ScruffyNerfHerderSabers.Models;

namespace ScruffyNerfHerderSabers.DAL
{
    public class StoreInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{FirstMidName="Depa",LastName="Billaba",Rank="Jedi Master", TransactionDate=DateTime.Parse("1999-01-13")},
                new Customer{FirstMidName="Kav",LastName="Bayons",Rank="Jedi Knight", TransactionDate=DateTime.Parse("2000-02-14")},
                new Customer{FirstMidName="Whie",LastName="Bene",Rank="Padawan", TransactionDate=DateTime.Parse("2002-07-12")},
                new Customer{FirstMidName="Darth",LastName="Zannah",Rank="Sith Lord", TransactionDate=DateTime.Parse("2001-03-16")},
                new Customer{FirstMidName="Darth",LastName="Nihilus",Rank="Sith Lord", TransactionDate=DateTime.Parse("2003-11-15")},
                new Customer{FirstMidName="Exar",LastName="Kun",Rank="Jedi Master/Sith", TransactionDate=DateTime.Parse("2004-10-21")}
            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product{ProductID= 1, ProductName="Defender",UPC= 123, Price=10499, Inventory=3, Color="Blue", Hilt="Curved", Hand="Main"},
                new Product{ProductID=2, ProductName="Overshadow",UPC=124, Price=10499, Inventory=7, Color="Black", Hilt="Dual", Hand="Both"},
                new Product{ProductID=3, ProductName="Savior", UPC=125, Price=10499, Inventory=2, Color="Green", Hilt="Standard", Hand="Off"},
                new Product{ProductID=4, ProductName="Conqueror",UPC=126, Price=10499, Inventory=1, Color="Blood Red", Hilt="Standard", Hand="Main"},
                new Product{ProductID=5, ProductName="Deliverer",UPC=127, Price=10499, Inventory=4,  Color="Purple", Hilt="Dual Spinning", Hand="Both"},
                new Product{ProductID=6, ProductName="Promise of Ended Dreams",UPC=128, Price=10499, Inventory=1, Color="Red", Hilt="Crossguard", Hand="Main"},
                new Product{ProductID=7, ProductName="Shortsword of Pride's Fall",UPC=129, Price=10499, Inventory=1, Color="Orange", Hilt="Curved", Hand="Off"}

            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
                new Transaction{CustomerID=1, ProductID=1},
                new Transaction{CustomerID=1, ProductID=7},
                new Transaction{CustomerID=2, ProductID=3},
                new Transaction{CustomerID=3, ProductID=5},
                new Transaction{CustomerID=4, ProductID=6},
                new Transaction{CustomerID=5, ProductID=4},
                new Transaction{CustomerID=6, ProductID=2},
            };

            transactions.ForEach(c => context.Transactions.Add(c));
            context.SaveChanges();
        }
    }
}