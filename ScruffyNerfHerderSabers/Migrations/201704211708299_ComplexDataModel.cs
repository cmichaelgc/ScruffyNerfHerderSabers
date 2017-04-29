namespace ScruffyNerfHerderSabers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DepartmentAssignment",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.ProductEmployee",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.EmployeeID })
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.EmployeeID);

            //Create a department for product to point to.
            //Sql("INSERT INTO dbo.Department (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
            // default value for FK points to department created above.
            //AddColumn("dbo.Product", "DepartmentID", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Product", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "Rank", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Product", "ProductName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            CreateIndex("dbo.Product", "DepartmentID");
            AddForeignKey("dbo.Product", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductEmployee", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.ProductEmployee", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.DepartmentAssignment", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.ProductEmployee", new[] { "EmployeeID" });
            DropIndex("dbo.ProductEmployee", new[] { "ProductID" });
            DropIndex("dbo.DepartmentAssignment", new[] { "EmployeeID" });
            DropIndex("dbo.Department", new[] { "EmployeeID" });
            DropIndex("dbo.Product", new[] { "DepartmentID" });
            AlterColumn("dbo.Product", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "ProductName", c => c.String());
            AlterColumn("dbo.Customer", "Rank", c => c.String());
            AlterColumn("dbo.Customer", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customer", "LastName", c => c.String(maxLength: 50));
            DropColumn("dbo.Product", "DepartmentID");
            DropTable("dbo.ProductEmployee");
            DropTable("dbo.DepartmentAssignment");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
