namespace AutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        Make = c.String(maxLength: 50),
                        Color = c.String(maxLength: 50),
                        PetName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustID, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.CarID)
                .Index(t => t.CustID)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.CreditRisks",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CustID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarID", "dbo.Tests");
            DropForeignKey("dbo.Orders", "CustID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CarID" });
            DropIndex("dbo.Orders", new[] { "CustID" });
            DropTable("dbo.CreditRisks");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Tests");
        }
    }
}
