using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;

namespace HotelManagement.Services.Services
{
    public interface IItemService
    {
        IEnumerable<Items> GetAllItems();
        void DeleteItem(Items item);
        void UpdateItem(Items item);
        Items GetItemById(int? id);
        Items AddItem(Items item);
        IEnumerable<string> GetItemByName(string itemName);
        IEnumerable<Items> GetListOfItemByName(string itemName);
    }
}
