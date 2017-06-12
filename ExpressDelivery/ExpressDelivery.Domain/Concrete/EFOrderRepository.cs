using ExpressDelivery.Domain.Entities;
using ExpressDelivery.Domain.Abstract;
using System.Linq;

namespace ExpressDelivery.Domain.Concrete
{
    public class EFOrderRepository : IOrdersRepository
    {
        private strExpressDeliveryEntities context = new strExpressDeliveryEntities();

        public IQueryable<Заказы> Orders
        {
            get { return context.Заказы; }
        }
    }
}