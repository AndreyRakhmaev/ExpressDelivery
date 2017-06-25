using ExpressDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpressDelivery.Controllers
{
    public class ServicesAndPlansController : Controller
    {
        public ActionResult index()
        {
            var list = Repository.Select<Тарифы>().ToList();
            return View(list);
        }
    }
}