using ScruffyNerfHerderSabers.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ScruffyNerfHerderSabers.DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DepartmentAssignment> DepartmentAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Employees).WithMany(i => i.Products)
                .Map(t => t.MapLeftKey("ProductID")
                    .MapRightKey("EmployeeID")
                    .ToTable("ProductEmployee"));


        }
    }
}