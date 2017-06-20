﻿using ExpressDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpressDelivery.Models
{
    public class CalculatorViewModel
    {
        public int? PlanId { get; set; }
        public List<Тарифы> Plans { get; set; }

        public double? Length { get; set; }
        public double? Width{ get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }

        public int?[] ServicesId { get; set; }
        public List<Услуги> Services { get; set; }

        public Тарифы getPlan() {
            var plan = Repository.Select<Тарифы>().Where(p => p.кодТарифа == PlanId).FirstOrDefault();
            return plan;
        }

        public List<Услуги> getServices()
        {
            for (int i = 0; i < ServicesId.Length; i++) {
                var services = Repository.Select<Услуги>().Where(p => p.кодУслуги == ServicesId[i]).FirstOrDefault();
                Services.Add(services);
            }
            return Services;
        }

        public double? getAmount()
        {
            return Length * Width * Height;
        }

        public decimal getCost()
        {
            //+35р за каждый кг груза
            //+25р за каждые 10 см. куб. объёма
            decimal cost = (decimal)(Weight * 35 + getAmount() / 10 * 25);
            return cost;
        }
    }
}