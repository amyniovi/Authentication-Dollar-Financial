using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace HostServer
{
   public class Program
   {
       private static readonly Uri BaseAddress = new Uri("http://localhost:58179");
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration(BaseAddress);
            config.MapHttpAttributeRoutes();

            //Create Server
            var server = new HttpSelfHostServer(config);

            //Start Listening

            server.OpenAsync().Wait();
            Console.WriteLine("Web API self hosted on " + BaseAddress + ".... hit Enter to exit");
            Console.ReadLine();
            server.CloseAsync().Wait();
        }
    }
}
