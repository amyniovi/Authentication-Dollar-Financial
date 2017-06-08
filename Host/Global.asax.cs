using System.Web;
using System.Web.Http;

namespace Dollar.Authentication.Host
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}