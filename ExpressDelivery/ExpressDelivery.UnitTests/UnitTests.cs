using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressDelivery.Domain;
using ExpressDelivery.Models;
using System.Collections.Generic;
using System.Linq;
using Moq;
using ExpressDelivery.Domain.Abstract;
using ExpressDelivery.Controllers;
using ExpressDelivery.Domain.Entities;
using System.Web.Mvc;

namespace ExpressDelivery.UnitTests
{
    [TestClass]
    public class UnitTests
    {

        OrderDetails p1 = new OrderDetails
        {
            OrderNumber = 1,
            FioFrom = "Иванов Иван Иванович",
            AdressFrom = "г Тестград, ул Тестовая, д 1, кв 1",
            ZipFrom = "123456",
            PhoneNumberFrom = "81234567890",
            EmailFrom = "test@test.ru",

            FioTo = "Петров Петр Петрович",
            AdressTo = "г ЮнитСити, ул Тестовая, д 1, кв 1",
            ZipTo = "123456",
            PhoneNumberTo = "81234567890",
            EmailTo = "test@test.ru",

            TrackingNumber = "1234567890",
            DimensionsDelivery = "1x1x1",
            WeightDelivery = 1,
            TypeDelivery = "Тестовый",
            Plan = "Тестовый",
            Comment = "Посылка тестируется",
            Services = "Тестовая",
            Worker = "Семёнов Семён Семёнович",
            DateOrder = DateTime.Now,
            RouteNumber = 1,
            ExtensionPath = 1,
            TimePath = 1,
            DateTo = DateTime.Now,

            PriceDelivery = 1
        };

        ///

        OrderDetails p2 = new OrderDetails
        {
            OrderNumber = 2,
            FioFrom = "Иванов Иван Иванович",
            AdressFrom = "г Тестград, ул Тестовая, д 1, кв 1",
            ZipFrom = "123456",
            PhoneNumberFrom = "81234567890",
            EmailFrom = "test@test.ru",

            FioTo = "Петров Петр Петрович",
            AdressTo = "г ЮнитСити, ул Тестовая, д 1, кв 1",
            ZipTo = "123456",
            PhoneNumberTo = "81234567890",
            EmailTo = "test@test.ru",

            TrackingNumber = "1234567890",
            DimensionsDelivery = "1x1x1",
            WeightDelivery = 1,
            TypeDelivery = "Тестовый",
            Plan = "Тестовый",
            Comment = "Посылка тестируется",
            Services = "Тестовая",
            Worker = "Семёнов Семён Семёнович",
            DateOrder = DateTime.Now,
            RouteNumber = 1,
            ExtensionPath = 1,
            TimePath = 1,
            DateTo = DateTime.Now,

            PriceDelivery = 1
        };

        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Arrange - create some test products
            

            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(p1);
            target.AddItem(p2);
            CartLine[] results = target.Lines.ToArray();
            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, p1);
            Assert.AreEqual(results[1].Product, p2);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            // Arrange - create some test products
           
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart
            target.AddItem(p1);
            target.AddItem(p2);
            // Act
            target.RemoveLine(p2);

            // Assert
            Assert.AreEqual(target.Lines.Where(c => c.Product == p2).Count(), 0);
            Assert.AreEqual(target.Lines.Count(), 1);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // Arrange - create some test products
            
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(p1);
            target.AddItem(p2);
            decimal result = target.ComputeTotalValue();
            // Assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            // Arrange - create some test products
            
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some items
            target.AddItem(p1);
            target.AddItem(p2);
            // Act - reset the cart
            target.Clear();
            // Assert
            Assert.AreEqual(target.Lines.Count(), 0);
        }

        [TestMethod]
        public void Can_Add_To_Cart()
        {
            // Arrange - create the mock repository
            Mock<IOrdersRepository> mock = new Mock<IOrdersRepository>();
            mock.Setup(m => m.Orders).Returns(new Заказы[] {
            new Заказы {кодЗаказа = 1, стоимостьЗзаказа=1},
            }.AsQueryable());
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            // Act - add a product to the cart
            target.AddToCart(cart, p1, null);
            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.OrderNumber, p1.OrderNumber);
        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            // Arrange - create the mock repository
            Mock<IOrdersRepository> mock = new Mock<IOrdersRepository>();
            mock.Setup(m => m.Orders).Returns(new Заказы[] {
            new Заказы {кодЗаказа = 1, стоимостьЗзаказа=1},
            }.AsQueryable());
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            // Act - add a product to the cart
            RedirectToRouteResult result = target.AddToCart(cart, p1, "myUrl");
            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(null);
            // Act - call the Index action method
            CartIndexViewModel result = (CartIndexViewModel)target.Index(cart,
            "myUrl").ViewData.Model;
            // Assert
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}
