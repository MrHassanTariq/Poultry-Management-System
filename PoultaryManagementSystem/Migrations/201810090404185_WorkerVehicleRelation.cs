namespace PoultaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkerVehicleRelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Workers",new[] { "ID"} );
            DropColumn("dbo.Workers",   "ID" );
            AddColumn("dbo.Vehicles", "WorkerID", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "vehicle_VehicleID", c => c.Int());
            AddColumn("dbo.Workers", "WorkerID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Workers", "WorkerID");
            CreateIndex("dbo.Vehicles", "WorkerID");
            CreateIndex("dbo.Vehicles", "vehicle_VehicleID");
            AddForeignKey("dbo.Vehicles", "vehicle_VehicleID", "dbo.Vehicles", "VehicleID");
            AddForeignKey("dbo.Vehicles", "WorkerID", "dbo.Workers", "WorkerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Vehicles", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.Vehicles", "vehicle_VehicleID", "dbo.Vehicles");
            DropIndex("dbo.Vehicles", new[] { "vehicle_VehicleID" });
            DropIndex("dbo.Vehicles", new[] { "WorkerID" });
            DropPrimaryKey("dbo.Workers");
            DropColumn("dbo.Workers", "WorkerID");
            DropColumn("dbo.Vehicles", "vehicle_VehicleID");
            DropColumn("dbo.Vehicles", "WorkerID");
            AddPrimaryKey("dbo.Workers", "ID");
        }
    }
}
