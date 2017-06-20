using ExpressDelivery.Domain.Entities;
using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpressDelivery.Controllers
{
    public class forCustomersController : Controller
    {
        // GET: forCustomers
        public ActionResult POZ()
        {
            return View();
        }

        public ActionResult kalkulyator(CalculatorViewModel viewModel, decimal? perPlan, decimal? perDelivery)
        {
            CalculatorViewModel plan = new CalculatorViewModel
            {
                PlanId = viewModel.PlanId != null ? viewModel.PlanId : null,
                Plans = Repository.Select<Тарифы>().ToList(),
                Length = viewModel.Length,
                Width = viewModel.Width,
                Height = viewModel.Height,
                Weight = viewModel.Weight
            };
                //decimal[] cost = new decimal[2];
                //cost[0] = plan.getPlan().стоимостьТарифа;
                //cost[1] = plan.getCost();
                //decimal cost = plan.getCost();
                //ViewBag.Result = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(cost);
            return View(plan);
        }
    }
}