using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;
using System.Data.Entity;

namespace HotelManagement.Data.Repositories
{

    public interface IItemsRepository : IRepository<Items>
    {

        new Items Get(int? id);
        List<string> GetItemByName(string itemName);
        IEnumerable<Items> GetListOfItemByName(string itemName);
    }
    public class ItemsRepository : GenericRepository<Items>, IItemsRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public ItemsRepository(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        Items IItemsRepository.Get(int? id)
        {
            return _hotelDbContext.Items.Include("Menu").FirstOrDefault(x => x.ItemId == id);

        }

        public override IEnumerable<Items> Get()
        {
            return _hotelDbContext.Items.Include("Menu").ToList();

        }

        public List<string> GetItemByName(string itemName)
        {
            return _hotelDbContext.Items.Where(x => x.Name.Contains(itemName)).Select(x => x.Name).Distinct().ToList();
        }

        public IEnumerable<Items> GetListOfItemByName(string itemName)
        {
            return _hotelDbContext.Items.Include("Menu").Where(x => x.Name.Contains(itemName)).ToList();
        }
    }
}
