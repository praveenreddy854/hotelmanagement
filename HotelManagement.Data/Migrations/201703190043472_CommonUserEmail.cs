namespace HotelManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommonUserEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Admins", "UserName");
            DropColumn("dbo.Customers", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Admins", "Email");
        }
    }
}
