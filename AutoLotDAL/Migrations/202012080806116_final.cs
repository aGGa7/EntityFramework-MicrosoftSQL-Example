namespace AutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CarID", "dbo.Tests");
            DropForeignKey("dbo.Orders", "CustID", "dbo.Customers");
            RenameColumn(table: "dbo.Orders", name: "CustID", newName: "CustomerID");
            RenameIndex(table: "dbo.Orders", name: "IX_CustID", newName: "IX_CustomerID");
            DropPrimaryKey("dbo.Tests");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.CreditRisks");
            DropColumn("dbo.Tests", "CarID");
            DropColumn("dbo.Orders", "OrderID");
            DropColumn("dbo.Customers", "CustID");
            DropColumn("dbo.CreditRisks", "CustID");
            AddColumn("dbo.Tests", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Tests", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.CreditRisks", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisks", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddPrimaryKey("dbo.Tests", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.CreditRisks", "Id");
            CreateIndex("dbo.CreditRisks", new[] { "LastName", "FirstName" }, unique: true, name: "IDX_CreditRisk_Name");
            AddForeignKey("dbo.Orders", "CarID", "dbo.Tests", "Id");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CarID", "dbo.Tests");
            DropPrimaryKey("dbo.CreditRisks");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Tests");
            DropColumn("dbo.CreditRisks", "TimeStamp");
            DropColumn("dbo.CreditRisks", "Id");
            DropColumn("dbo.Customers", "TimeStamp");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.Orders", "TimeStamp");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Tests", "TimeStamp");
            DropColumn("dbo.Tests", "Id");

            AddColumn("dbo.CreditRisks", "CustID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "CustID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "OrderID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Tests", "CarID", c => c.Int(nullable: false, identity: true));
           
            DropIndex("dbo.CreditRisks", "IDX_CreditRisk_Name");
          
            AddPrimaryKey("dbo.CreditRisks", "CustID");
            AddPrimaryKey("dbo.Customers", "CustID");
            AddPrimaryKey("dbo.Orders", "OrderID");
            AddPrimaryKey("dbo.Tests", "CarID");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerID", newName: "IX_CustID");
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "CustID");
            AddForeignKey("dbo.Orders", "CustID", "dbo.Customers", "CustID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CarID", "dbo.Tests", "CarID");
        }
    }
}
