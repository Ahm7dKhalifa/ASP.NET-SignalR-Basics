﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthorizationWithSignalR.Startup))]
namespace AuthorizationWithSignalR
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
