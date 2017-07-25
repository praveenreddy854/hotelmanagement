using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelManagement.Services.Services;
using HotelManagement.Data.Repositories;
using Moq;
using HotelManagement.Models.Models;
using System.Collections.Generic;

namespace HotelManagement.Test
{
    [TestClass]
    public class ItemsServiceTest
    {
        private IItemService _itemService;
        private IItemsRepository _itemRepository;
        private Mock<IItemsRepository> _mockItemRepository;

        [TestMethod]
        public void TestNumberOfItemAreEqualToFiveOrNOt()
        {
            IList<Items> items = (IList<Items>)_itemService.GetAllItems();
            Assert.AreEqual(3, items.Count);
        }

        [TestMethod]
        public void TestAddItemItemServiceByAddingAnItem()
        {
            Items item = new Items { ItemId = 4, Name = "Mirchi", Price = 1.0M, MenuId = 3 };
            _mockItemRepository.Setup(x => x.Create(It.IsAny<Items>())).Returns(item);
            Assert.AreEqual(item.ItemId, _itemService.AddItem(item).ItemId);
        }

        [TestMethod]
        public void TestGetItemByIdItemServiceByPassingId()
        {
            _mockItemRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Items { ItemId = 1, Name = "Puri", Price = 10.0M, MenuId = 1 });
            Assert.AreEqual(1, _itemService.GetItemById(1).ItemId);

        }
        [TestMethod]
        public void TestDeleteItemServiceMethodByItemId()
        {
            //Arranage
            Items item = new Items { ItemId = 4, Name = "Mirchi", Price = 1.0M, MenuId = 3 };
            
            //set up the method to be called
            _mockItemRepository.Setup(x => x.Delete(It.IsAny<Items>()));

            //Act
            _itemService.DeleteItem(item);

            //Assert
            _mockItemRepository.Verify(x=>x.Delete(item));
            
        }

        [TestInitialize]
        public void Initialize()
        {
            _mockItemRepository = new Mock<IItemsRepository>();
            _itemService = new ItemService(_mockItemRepository.Object);
            _itemRepository = _mockItemRepository.Object;
            
            var items = new List<Items> {
                new Items{ ItemId=1,Name="Puri", Price=10.0M,MenuId=1},
                new Items{ ItemId=2,Name="Dosa", Price=12.0M,MenuId=1},
                new Items{ ItemId=3,Name="Biryani", Price=10.0M,MenuId=2}
            };
            _mockItemRepository.Setup(mock => mock.Get()).Returns(items);
        }
    }
}
