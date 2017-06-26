using ExpressDelivery.Domain.Entities;
using ExpressDelivery.Models;
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
            ServicesAndPlansViewModel viewModel = new ServicesAndPlansViewModel();
            return View(viewModel);
        }
    }
}