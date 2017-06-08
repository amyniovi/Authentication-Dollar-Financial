using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dollar.Authentication.Client
{
    public interface IConfiguration 
    {
        string ResourceName { get; }
        string AuthTimeout { get; }
        string ServerEndpoint { get; }
    }
}
