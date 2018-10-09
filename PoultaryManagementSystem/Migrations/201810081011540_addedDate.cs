namespace PoultaryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "date");
        }
    }
}
