using ExpressDelivery.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpressDelivery.Models
{
    public class OrderDetails
    {
        public int OrderNumber { get; set; }
        public string FioFrom { get; set; }
        public string AdressFrom { get; set; }
        public string ZipFrom { get; set; }
        public string PhoneNumberFrom { get; set; }
        public string EmailFrom { get; set; }

        public string FioTo { get; set; }
        public string AdressTo { get; set; }
        public string ZipTo { get; set; }
        public string PhoneNumberTo { get; set; }
        public string EmailTo { get; set; }

        public string TrackingNumber { get; set; }
        public string DimensionsDelivery { get; set; }
        public double WeightDelivery { get; set; }
        public string TypeDelivery { get; set; }
        public string Plan { get; set; }
        public string Comment { get; set; }
        public string Services { get; set; }
        public string Worker { get; set; }
        public DateTime DateOrder { get; set; }
        public int RouteNumber { get; set; }
        public double ExtensionPath { get; set; }
        public double TimePath { get; set; }
        public DateTime DateTo { get; set; }

        public decimal PriceDelivery { get; set; }

        public string OrderComment { get; set; }
        public string OrderStatus { get; set; }
    }
}