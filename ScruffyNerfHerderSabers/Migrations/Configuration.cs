namespace ScruffyNerfHerderSabers.Migrations
{
    using ScruffyNerfHerderSabers.Models;
    using ScruffyNerfHerderSabers.DAL;
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

            customers.ForEach(c => context.Customers.AddOrUpdate(p => p.LastName, c));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee {FirstMidName = "Jim", LastName = "Jameson", HireDate = DateTime.Parse("1999-03-12")},
                new Employee {FirstMidName = "Rob", LastName = "Robinson", HireDate = DateTime.Parse("1994-04-15")},
                new Employee {FirstMidName = "Dave", LastName = "Davidson", HireDate = DateTime.Parse("1989-01-20")},
                new Employee {FirstMidName = "Will", LastName = "Williamson", HireDate = DateTime.Parse("2001-07-22")},
                new Employee {FirstMidName = "Bruce", LastName = "Holloway", HireDate = DateTime.Parse("1993-12-19")},
            };
            employees.ForEach(c => context.Employees.AddOrUpdate(p => p.LastName, c));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department {Name = "Dark", Budget = 800000, StartDate = DateTime.Parse("1999-12-11"), EmployeeID = employees.Single( i => i.LastName == "Jameson").ID},
                new Department {Name = "Dark", Budget = 800000, StartDate = DateTime.Parse("1994-12-11"), EmployeeID = employees.Single( i => i.LastName == "Robinson").ID},
                new Department {Name = "Light", Budget = 1800000, StartDate = DateTime.Parse("2002-01-12"), EmployeeID = employees.Single( i => i.LastName == "Williamson").ID}
            };
            departments.ForEach(c => context.Departments.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product{ProductID= 1, ProductName="Defender",UPC= 123, Price=10499, Inventory=3, Color="Blue", Hilt="Curved", Hand="Main", DepartmentID = departments.Single (c => c.Name == "Light").DepartmentID, Employees = new List<Employee>()},
                new Product{ProductID=2, ProductName="Overshadow",UPC=124, Price=10499, Inventory=7, Color="Black", Hilt="Dual", Hand="Both", DepartmentID = departments.Single (c => c.Name == "Dark").DepartmentID, Employees = new List<Employee>()},
                new Product{ProductID=3, ProductName="Savior", UPC=125, Price=10499, Inventory=2, Color="Green", Hilt="Standard", Hand="Off", DepartmentID = departments.Single (c => c.Name == "Light").DepartmentID, Employees = new List<Employee>()},
                new Product{ProductID=4, ProductName="Conqueror",UPC=126, Price=10499, Inventory=1, Color="Blood Red", Hilt="Standard", Hand="Main", DepartmentID = departments.Single (c => c.Name == "Dark").DepartmentID, Employees = new List<Employee>()},
                new Product{ProductID=5, ProductName="Deliverer",UPC=127, Price=10499, Inventory=4,  Color="Purple", Hilt="Dual Spinning", Hand="Both", DepartmentID = departments.Single (c => c.Name == "Light").DepartmentID, Employees = new List<Employee>()},
                new Product{ProductID=6, ProductName="Promise of Ended Dreams",UPC=128, Price=10499, Inventory=1, Color="Red", Hilt="Crossguard", Hand="Main", DepartmentID = departments.Single (c => c.Name == "Dark").DepartmentID, Employees = new List<Employee>()},
                new Product{ProductID=7, ProductName="Shortsword of Pride's Fall",UPC=129, Price=10499, Inventory=1, Color="Orange", Hilt="Curved", Hand="Off", DepartmentID = departments.Single (c => c.Name == "Light").DepartmentID, Employees = new List<Employee>()}

            };

            products.ForEach(c => context.Products.AddOrUpdate(p => p.ProductName, c));
            context.SaveChanges();

            var departmentAssignments = new List<DepartmentAssignment>
            {
                new DepartmentAssignment
                {
                    EmployeeID = employees.Single( e => e.LastName == "Jameson").ID, Location = "Hoth"
                },
                new DepartmentAssignment
                {
                    EmployeeID = employees.Single( e => e.LastName == "Robinson").ID, Location = "Bespin"
                },
                new DepartmentAssignment
                {
                    EmployeeID = employees.Single( e => e.LastName == "Davidson").ID, Location = "Mustafar"
                },
                new DepartmentAssignment
                {
                    EmployeeID = employees.Single( e => e.LastName == "Williamson").ID, Location = "Kamino"
                },
                new DepartmentAssignment
                {
                    EmployeeID = employees.Single( e => e.LastName == "Holloway").ID, Location = "Kashyyyk"
                }
            };
            departmentAssignments.ForEach(c => context.DepartmentAssignments.AddOrUpdate(p => p.EmployeeID, c));
            context.SaveChanges();

            AddOrUpdateEmployee(context, "Dark", "Jameson");
            AddOrUpdateEmployee(context, "Light", "Robinson");
            AddOrUpdateEmployee(context, "Dark", "Davidson");
            AddOrUpdateEmployee(context, "Light", "Williamson");
            AddOrUpdateEmployee(context, "Light", "Holloway");

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

        void AddOrUpdateEmployee(StoreContext context, string productName, string employeeName)
        {
            var crs = context.Products.SingleOrDefault(c => c.ProductName == productName);
            var inst = crs.Employees.SingleOrDefault(i => i.LastName == employeeName);
            if (inst == null)
                crs.Employees.Add(context.Employees.Single(i => i.LastName == employeeName));
        }
    }
}
