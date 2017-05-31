using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpressDelivery.Startup))]
namespace ExpressDelivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
