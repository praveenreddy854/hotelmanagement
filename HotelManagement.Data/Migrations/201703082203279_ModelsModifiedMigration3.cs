namespace HotelManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsModifiedMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Role");
        }
    }
}
