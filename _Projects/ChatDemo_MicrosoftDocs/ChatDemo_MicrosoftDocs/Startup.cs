using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatDemo_MicrosoftDocs.Startup))]
namespace ChatDemo_MicrosoftDocs
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
