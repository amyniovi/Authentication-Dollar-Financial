using Dollar.Authentication.TestWebSite;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace Dollar.Authentication.TestWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}