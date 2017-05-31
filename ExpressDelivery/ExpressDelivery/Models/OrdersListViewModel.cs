using ExpressDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressDelivery.Models
{
    public class OrdersListViewModel
    {
        public IEnumerable<Заказы> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}