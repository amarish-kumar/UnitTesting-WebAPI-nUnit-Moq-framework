using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookingTek.WebUI.Startup))]
namespace BookingTek.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
