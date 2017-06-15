using ExpressDelivery.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpressDelivery.Models
{
    public class OrderDetails
    {
        public int OrderNumber { get; set; }
        [Required(ErrorMessage = "Введите ФИО отправителя")]
        public string FioFrom { get; set; }
        [Required(ErrorMessage = "Введите город отправления")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите адрес отправителя")]
        public string AdressFrom { get; set; }
        public string ZipFrom { get; set; }
        [Required(ErrorMessage = "Введите номер телефона отправителя")]
        public string PhoneNumberFrom { get; set; }
        [Required(ErrorMessage = "Введите адрес эл. почты отправителя")]
        public string EmailFrom { get; set; }

        [Required(ErrorMessage = "Введите ФИО получателя")]
        public string FioTo { get; set; }
        [Required(ErrorMessage = "Введите город назначения")]
        public string CityTo { get; set; }
        [Required(ErrorMessage = "Введите адрес получателя")]
        public string AdressTo { get; set; }
        public string ZipTo { get; set; }
        [Required(ErrorMessage = "Введите телефонный номер получателя")]
        public string PhoneNumberTo { get; set; }
        public string EmailTo { get; set; }

        public string TrackingNumber { get; set; }
        [Required(ErrorMessage = "Введите габариты груза")]
        public string DimensionsDelivery { get; set; }
        [Required(ErrorMessage = "Введите массу груза")]
        public double WeightDelivery { get; set; }
        [Required(ErrorMessage = "Введите тип груза")]
        public string TypeDelivery { get; set; }
        [Required(ErrorMessage = "Введите тарифный план")]
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