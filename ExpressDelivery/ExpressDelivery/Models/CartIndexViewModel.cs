using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressDelivery.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public int StatusId { get; set; }
        public List<string> Statuses { get { return new List<string> { "Заказ в обработке", "Подтвержден","Отменен" } ; } }
    }
}