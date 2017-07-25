using HotelManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Repositories
{

    public interface ICustomerRepository : IRepository<Customer>
    {

    }
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {
        }
    }
}
