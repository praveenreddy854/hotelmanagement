using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;
using HotelManagement.Data;
using HotelManagements.Models.Models;

namespace HotelManagement.Data.Repositories
{
    public interface ICommonUserRepository
    {
        dynamic ValidateUser(string email, string password);
        
    }
    public class CommonUserRepository : ICommonUserRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public CommonUserRepository(HotelDbContext hotelDbContext)
        {
            hotelDbContext = _hotelDbContext;
        }

        public dynamic ValidateUser(string email,string password)
        {
            return _hotelDbContext.Customers.Select(x=>new { x.FirstName,x.LastName,x.Email,x.Password,x.Role}).FirstOrDefault(x => x.Email == email && x.Password == password)??_hotelDbContext.Admins.Select(x=>new { x.FirstName, x.LastName, x.Email, x.Password , x.Role }).FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
