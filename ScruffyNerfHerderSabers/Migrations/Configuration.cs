namespace ScruffyNerfHerderSabers.Migrations
{
    using ScruffyNerfHerderSabers.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ScruffyNerfHerderSabers.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ScruffyNerfHerderSabers.DAL.StoreContext context)
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

            customers.ForEach(c => context.Customers.AddOrUpdate(p => p.LastName, c));
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

            products.ForEach(c => context.Products.AddOrUpdate(p => p.ProductName, c));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    CustomerID = customers.Single(c => c.LastName =="Billaba").ID,
                    ProductID = products.Single(d => d.ProductName == "Defender").ProductID
                },

                new Transaction
                {
                    CustomerID = customers.Single(c => c.LastName =="Billaba").ID,
                    ProductID = products.Single(d => d.ProductName == "Shortsword of Pride's Fall").ProductID
                },

                new Transaction
                {
                    CustomerID = customers.Single(c => c.LastName =="Bayons").ID,
                    ProductID = products.Single(d => d.ProductName == "Savior").ProductID
                },

                new Transaction
                {
                    CustomerID = customers.Single(c => c.LastName =="Bene").ID,
                    ProductID = products.Single(d => d.ProductName == "Deliverer").ProductID
                },

                new Transaction
                {
                    CustomerID = customers.Single(c => c.LastName =="Zannah").ID,
                    ProductID = products.Single(d => d.ProductName == "Promise of Ended Dreams").ProductID
                },

                new Transaction
                {
                    CustomerID = customers.Single(c => c.LastName =="Nihilus").ID,
                    ProductID = products.Single(d => d.ProductName == "Conqueror").ProductID
                },

                new Transaction
                {
                    CustomerID = customers.Single(c => c.LastName =="Kun").ID,
                    ProductID = products.Single(d => d.ProductName == "Overshadow").ProductID
                }
            };

            foreach (Transaction t in transactions)
            {
                var transactionInDataBase = context.Transactions.Where(
                    c =>
                        c.Customer.ID == t.CustomerID &&
                        c.Product.ProductID == t.ProductID).SingleOrDefault();
                if (transactionInDataBase == null)
                {
                    context.Transactions.Add(t);
                }
            }
            context.SaveChanges();
        }
    }
}
