using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Models;
using HotelManagement.Data;
using HotelManagement.Data.Repositories;

namespace HotelManagement.Services.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public Menu AddMenu(Menu menu)
        {
            return _menuRepository.Create(menu);
        }

        public void DeleteMenu(Menu menu)
        {
            _menuRepository.Delete(menu);
        }

        public IEnumerable<Menu> GetAllMenu()
        {
            return _menuRepository.Get();
        }

        public Menu GetById(int? id)
        {
            return _menuRepository.Get(id);
        }

        public void UpdateMenu(Menu menu)
        {
            _menuRepository.Put(menu);
        }

        public IEnumerable<string> GetOnlyMenuDetails()
        {
            return _menuRepository.GetOnlyMenuDetails();
        }
    }
}
