using ExpressDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressDelivery.Models
{
    public class ServicesAndPlansViewModel
    {
        public List<Тарифы> Plans { get { return Repository.Select<Тарифы>().ToList(); } }
        public List<Услуги> Services { get { return Repository.Select<Услуги>().ToList(); } }
        public List<Акции> Shares { get { return Repository.Select<Акции>().ToList(); } }
    }
}