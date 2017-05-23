namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationfixingdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Notifications", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Type");
            DropColumn("dbo.Notifications", "DateTime");
        }
    }
}
