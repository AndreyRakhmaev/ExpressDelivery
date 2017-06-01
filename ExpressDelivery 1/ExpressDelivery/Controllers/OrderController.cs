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

       public List<Заказы> selectOrders()
        {
            var orders = Repository.Select<Заказы>().OrderByDescending(c => c.датаЗаказа).ToList();
            return orders;
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