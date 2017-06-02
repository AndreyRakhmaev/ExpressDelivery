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
        public string OrderStatus { get; set; }
    }
}