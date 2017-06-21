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

        public ActionResult kalkulyator(CalculatorViewModel viewModel)
        {
            CalculatorViewModel plan = new CalculatorViewModel
            {
                PlanId = viewModel.PlanId,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Height = viewModel.Height,
                Weight = viewModel.Weight,
                Distance = viewModel.Distance
            };
            if (viewModel.Distance != 0)
            {
                plan.Amount = getAmount(plan.Length, plan.Width, plan.Height);
                plan.TotalCost = getTotalCost(plan.getSelectPlan().стоимостьТарифа, plan.Distance, plan.Amount, plan.Weight);
            }
            return View(plan);
        }

        public double getAmount(double length, double width, double height)
        {
            return length * width * height;
        }

        public decimal getTotalCost(decimal costPlan, double distance, double amount, double weight)
        {
            //+35р за каждый кг груза
            //+25р за каждые 10 см. куб. объёма
            decimal cost = costPlan * (decimal)distance + (decimal)weight * 35 + (decimal)amount / 10 * 25;
            return cost;
        }
    }
}