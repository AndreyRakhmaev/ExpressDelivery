using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using ExpressDelivery.Domain.Abstract;
using ExpressDelivery.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using ExpressDelivery.Domain.Concrete;

namespace ExpressDelivery.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IOrdersRepository>().To<EFOrderRepository>();

            //Mock<IOrdersRepository> mock = new Mock<IOrdersRepository>();
            //mock.Setup(m => m.Orders).Returns(new List<Order> {
            //new Order {
            //    OrderID = 1,
            //    DateOrder = DateTime.Today,
            //    FullNameTo = "Иванов Иван Иванович",
            //    AdressTo = "г Омск, ул Омская 1, д 1, кв 1",
            //    ZipTo = 123456,
            //    OrderPrice = 123,
            //    Comment = "Мой первый заказ",

            //    WorkerId = 1,
            //    CustomerId = 1,
            //    PlanId = 1,
            //    ServiceId = 1,
            //    PaymentId = 1,
            //    RouteId = 1
            //} }
            //.AsQueryable());
            //ninjectKernel.Bind<IOrdersRepository>().ToConstant(mock.Object);
        }
    }
}