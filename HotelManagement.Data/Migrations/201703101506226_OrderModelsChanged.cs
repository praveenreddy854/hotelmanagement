namespace HotelManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModelsChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "IsInKart", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "IsInKart");
            DropColumn("dbo.Orders", "OrderStatus");
        }
    }
}
