using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;
using HotelManagement.Services.Services;

namespace HotelManagement.Services.Services
{
    
    public interface IMenuService
    {
        IEnumerable<Menu> GetAllMenu();
        Menu GetById(int? id);
        void UpdateMenu(Menu mmenu);
        void DeleteMenu(Menu menu);
        Menu AddMenu(Menu menu);
        IEnumerable<string> GetOnlyMenuDetails();
    }
}
