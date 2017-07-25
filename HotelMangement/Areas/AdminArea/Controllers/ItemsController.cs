using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Data;
using HotelManagement.Models.Models;
using HotelManagement.Models.ModelView;
using HotelManagement.Services.Services;
using PagedList.Mvc;
using PagedList;

namespace HotelManagement.Areas.AdminArea.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMenuService _menuService;
        public ItemsController(IItemService itemService, IMenuService menuService)
        {
            _itemService = itemService;
            _menuService = menuService;
        }


        
        // GET: AdminArea/Items
        public ActionResult Index(int? page)
        {
            ViewBag.MenuDetails = _menuService.GetOnlyMenuDetails();
            var items = _itemService.GetAllItems();
            int pageNumber = page ?? 1;
            int pageSize = 10;
            ViewBag.OnePageItem = items.ToPagedList(pageNumber, pageSize);
            return View(ViewBag.OnePageItem);
        }

        // GET: AdminArea/Items/Details/5
        [HandleError()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Items items = _itemService.GetItemById(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        public ActionResult SearchItems(string itemName,int? page)
        {
            ViewBag.MenuDetails = _menuService.GetOnlyMenuDetails();
            var items = _itemService.GetListOfItemByName(itemName);
            int pageNumber = page ?? 1;
            int pageSize = items.Count();
            ViewBag.OnePageItem = items.ToPagedList(pageNumber, pageSize);
            return View("Index", ViewBag.OnePageItem);
        }

        // GET: AdminArea/Items/Create
        public ActionResult Create()
        {
            ViewBag.MenuDesc = new SelectList(_menuService.GetAllMenu(), "MenuId", "MenuDetails");
            return View();
        }

        // POST: AdminArea/Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,Name,Price,MenuId")] Items item)
        {
            
            if (ModelState.IsValid)
            {
               
                _itemService.AddItem(item);
                return RedirectToAction("Index");
            }

            ViewBag.MenuDesc = new SelectList(_menuService.GetAllMenu(), "MenuId", "MenuDescription", item.MenuId);
            return View(item);
        }

        // GET: AdminArea/Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = _itemService.GetItemById(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuDetails = new SelectList(_menuService.GetAllMenu(), "MenuId", "MenuDetails", items.Menu.MenuDetails);
            return View(items);
        }

        // POST: AdminArea/Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,Name,Price,MenuId")] Items items)
        {
            if (ModelState.IsValid)
            {
                _itemService.UpdateItem(items);
                return RedirectToAction("Index");
            }
            ViewBag.MenuDetails = new SelectList(_menuService.GetAllMenu(), "MenuId", "MenuDetails", _menuService.GetById(items.MenuId));
            return View(items);
        }

        // GET: AdminArea/Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = _itemService.GetItemById(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: AdminArea/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Items item)
        {
            _itemService.DeleteItem(item);
            return RedirectToAction("Index");
        }

        
    }
}
