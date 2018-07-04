using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentABike.Startup))]
namespace RentABike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
