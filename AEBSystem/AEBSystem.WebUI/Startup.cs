using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AEBSystem.WebUI.Startup))]
namespace AEBSystem.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
