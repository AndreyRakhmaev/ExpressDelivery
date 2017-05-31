using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpressDelivery.Domain.Entities;
using System.Data.Entity;

namespace ExpressDelivery.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(): base("EFDbContext"){ }

        public DbSet<Заказы> Orders { get; set; }
    }
}