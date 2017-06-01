using ExpressDelivery.Domain.Entities;
using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressDelivery.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(OrderDetails product)
        {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                });
        }
        public void RemoveLine(OrderDetails product)
        {
            lineCollection.RemoveAll(l => l.Product.OrderNumber == product.OrderNumber);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.PriceDelivery);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
    public class CartLine
    {
        public OrderDetails Product { get; set; }
    }
}