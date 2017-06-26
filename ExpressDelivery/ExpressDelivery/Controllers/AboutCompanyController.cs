using ExpressDelivery.Domain.Entities;
using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpressDelivery.Controllers
{
    public class AboutCompanyController : Controller
    {
        // GET: AboutCompany
        public ActionResult PunktyPriyemaIVydachi()
        {
            return View();
        }

       [HttpGet]
        public JsonResult PunktyPriyemaIVydachi2()
        {
            DataManager dm = new DataManager();
            return Json(dm.GetListObjectMap(), JsonRequestBehavior.AllowGet);
        }
    }
}