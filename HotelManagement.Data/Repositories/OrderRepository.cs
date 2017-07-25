using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;

namespace HotelManagement.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {

    }
    public class OrderRepository : GenericRepository<Order> , IOrderRepository
    {
        public OrderRepository(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {

        }
    }
}
