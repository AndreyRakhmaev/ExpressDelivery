using System.Linq;
using ExpressDelivery.Domain.Entities;

namespace ExpressDelivery.Domain.Abstract
{
    public interface IOrdersRepository
    {
        IQueryable<Заказы> Orders { get; }
    }
}
