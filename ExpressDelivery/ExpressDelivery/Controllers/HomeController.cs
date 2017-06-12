using ExpressDelivery.Domain.Abstract;
using ExpressDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpressDelivery.Controllers
{

    public class HomeController : Controller
    {
        private IOrdersRepository repository;
        public HomeController(IOrdersRepository orderRepository)
        {
            this.repository = orderRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Develop()
        {
            return View();
        }

        public ActionResult Comments()
        {
            var comments = Repository.Select<Комментарии>().OrderBy(x => x.датаКомментария).ToList();
            return View(comments);
        }

        public ActionResult Geolocation()
        {
            return View();
        }
    }
}