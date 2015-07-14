using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCommerce.WebUI.Startup))]
namespace eCommerce.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
