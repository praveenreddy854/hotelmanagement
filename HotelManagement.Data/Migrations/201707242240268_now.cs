namespace HotelManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class now : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "IsInKart", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.OrderDetails", "IsInKart");
            DropColumn("dbo.Orders", "OrderStatus");
            DropColumn("dbo.Customers", "Email");
            DropTable("dbo.Admins");
        }
    }
}
