using ExpressDelivery.Domain.Abstract;
using ExpressDelivery.Domain.Entities;
using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpressDelivery.Controllers
{
    public class CartController : Controller
    {
        private IOrdersRepository repository;
        public CartController(IOrdersRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, OrderDetails newOrder, string returnUrl = ""){
            Random rand = new Random();
            newOrder.OrderNumber = rand.Next();
            newOrder.DateOrder = DateTime.Now;
            newOrder.DateTo = DateTime.Now.AddDays(3);
            if (newOrder != null)
            {
                cart.AddItem(newOrder);
            }
            return RedirectToAction("Index", "Manage", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int orderId, string returnUrl = "")
        {
            CartLine cartLie = cart.Lines.Where(p => p.Product.OrderNumber == orderId).FirstOrDefault();
            OrderDetails order = cartLie.Product;
            if (order != null)
            {
                cart.RemoveLine(order);
            }
            return RedirectToAction("Index", "Manage", new { returnUrl });
        }

        public ViewResult ShowOrderDetails(Cart cart, int orderId)
        {
            CartLine cartLie = cart.Lines.Where(p => p.Product.OrderNumber == orderId).FirstOrDefault();
            OrderDetails order = cartLie.Product;
            return View(order != null ? order : null);
        }
    }
}