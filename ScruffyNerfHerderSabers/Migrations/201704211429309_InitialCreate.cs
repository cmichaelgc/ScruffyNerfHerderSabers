namespace ScruffyNerfHerderSabers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        Rank = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(),
                        UPC = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Inventory = c.Int(nullable: false),
                        Color = c.String(),
                        Hilt = c.String(),
                        Hand = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Transaction", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Transaction", new[] { "CustomerID" });
            DropIndex("dbo.Transaction", new[] { "ProductID" });
            DropTable("dbo.Product");
            DropTable("dbo.Transaction");
            DropTable("dbo.Customer");
        }
    }
}
