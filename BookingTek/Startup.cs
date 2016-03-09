using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookingTek.Startup))]
namespace BookingTek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
