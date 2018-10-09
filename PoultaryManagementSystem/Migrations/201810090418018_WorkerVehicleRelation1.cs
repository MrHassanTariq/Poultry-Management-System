namespace PoultaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkerVehicleRelation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "vehicle_VehicleID", "dbo.Vehicles");
            DropIndex("dbo.Vehicles", new[] { "vehicle_VehicleID" });
            DropColumn("dbo.Vehicles", "vehicle_VehicleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "vehicle_VehicleID", c => c.Int());
            CreateIndex("dbo.Vehicles", "vehicle_VehicleID");
            AddForeignKey("dbo.Vehicles", "vehicle_VehicleID", "dbo.Vehicles", "VehicleID");
        }
    }
}
