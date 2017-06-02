using ExpressDelivery.Domain.Abstract;
using ExpressDelivery.Domain.Entities;
using ExpressDelivery.Domain.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpressDelivery.Models;

namespace ExpressDelivery.Controllers
{
    public class OrderController : Controller
    {
        public int PageSize = 5;

        private ExpressDeliveryEntities context = new ExpressDeliveryEntities();
        private IOrdersRepository repository;
        public OrderController(IOrdersRepository orderRepository)
        {
            this.repository = orderRepository;
        }

        public ActionResult NewOrder()
        {
            OrderDetails newOrder = new OrderDetails();
            ViewBag.Message = "Оформление нового заказа";
            return View(newOrder);
        }

        public ViewResult List(int page = 1)
        {
            ViewBag.srvName = getSrvName();
            ViewBag.userName = getUserName();
            ViewBag.count = repository.Orders.Count();

            OrdersListViewModel model = new OrdersListViewModel
            {
                Orders = repository.Orders
                    .OrderBy(p => p.датаЗаказа)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Orders.Count()
                }
            };
            return View(model);
        }

        public RedirectToRouteResult RemoveFromDB(int orderId)
        {
            Repository.Delete(new Заказы
                    {
                       кодЗаказа = orderId
                    });
            return RedirectToAction("Index", "Manage");
        }

        //public ViewResult ShowOrderDetails(Cart cart, int orderId)
        //{
        //CartLine cartLie = cart.Lines.Where(p => p.Product.OrderNumber == orderId).FirstOrDefault();
        //OrderDetails order = cartLie.Product;
        //return View(order != null ? order : null);
        //}

        public ViewResult ListDelivery(string TrackNumber)
        {
            List<ИсторияОтслеживания> h = Repository.Select<ИсторияОтслеживания>().Where(x => x.Грузы.номерОтслеживания == TrackNumber).ToList();
            return View(h);
        }


        public string getUserName()
        {
            string userName = context.Database.SqlQuery<string>(
            "SELECT SYSTEM_USER").FirstOrDefault().ToString();
            return userName;
        }

        public string getSrvName()
        {
            string srvName = context.Database.SqlQuery<string>("SELECT CONVERT(sysname, SERVERPROPERTY('servername')) +' '+ CONVERT(sysname, SERVERPROPERTY('ProductVersion'))").FirstOrDefault().ToString();
            return srvName;
        }
    }
}