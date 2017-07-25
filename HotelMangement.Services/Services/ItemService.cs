using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;
using HotelManagement.Data;
using HotelManagement.Data.Repositories;
using System.Linq.Expressions;

namespace HotelManagement.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemService(IItemsRepository itemsRepository)
        {
            
            _itemsRepository = itemsRepository;
        }

        public Items AddItem(Items item)
        {
            return _itemsRepository.Create(item);
        }

        public void DeleteItem(Items item)
        {
            _itemsRepository.Delete(item);
        }

        public IEnumerable<Items> GetAllItems()
        {
            
            return _itemsRepository.Get();
        }

        public Items GetItemById(int? id)
        {
            return _itemsRepository.Get(id);
        }

        public void UpdateItem(Items item)
        {
            _itemsRepository.Put(item);
        }

        public IEnumerable<string> GetItemByName(string itemName)
        {
            return _itemsRepository.GetItemByName(itemName);
        }

        public IEnumerable<Items> GetListOfItemByName(string itemName)
        {
            return _itemsRepository.GetListOfItemByName(itemName);
        }
    }
}
