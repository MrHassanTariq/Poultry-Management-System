namespace PoultaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FarmHouses",
                c => new
                    {
                        FarmHouseID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Address = c.String(nullable: false, maxLength: 60),
                        orderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FarmHouseID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Weight = c.Int(nullable: false),
                        unitPrice = c.Int(nullable: false),
                        OrderNumber = c.String(maxLength: 10),
                        TotalWeightLeft = c.Int(),
                        Total = c.Int(),
                        FarmHouseID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.FarmHouses", t => t.FarmHouseID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.FarmHouseID)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Reatilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Weight = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Total = c.Int(),
                        date = c.DateTime(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 10),
                        Driver = c.String(nullable: false, maxLength: 60),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.VehicleID);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Reatilers", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "FarmHouseID", "dbo.FarmHouses");
            DropIndex("dbo.Reatilers", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "VehicleID" });
            DropIndex("dbo.Orders", new[] { "FarmHouseID" });
            DropTable("dbo.Workers");
            DropTable("dbo.Reports");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Reatilers");
            DropTable("dbo.Orders");
            DropTable("dbo.FarmHouses");
        }
    }
}
