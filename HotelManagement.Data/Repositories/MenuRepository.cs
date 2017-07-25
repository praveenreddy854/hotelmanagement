using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;
using HotelManagement.Data.Repositories;

namespace HotelManagement.Data.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
        IEnumerable<string> GetOnlyMenuDetails();
    }
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public MenuRepository(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public IEnumerable<string> GetOnlyMenuDetails()
        {
           return  _hotelDbContext.Menu.Select(x => x.MenuDetails.ToString()).ToList();
        }
    }
}
