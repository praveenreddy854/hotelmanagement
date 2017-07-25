using HotelManagement.Models.Models;
using HotelManagements.Models.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace HotelManagement.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Admin> Admins { get; set; }


        public HotelDbContext() : base("HotelDbContext")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        
    }
}
