namespace PoultaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnotationns : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "OrderNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "OrderNumber" });
        }
    }
}
