using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CallingHubFromController.Startup))]
namespace CallingHubFromController
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
