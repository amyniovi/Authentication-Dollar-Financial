using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dollar.Authentication.Common;

namespace Dollar.Authentication.Client
{
    public class Configuration : ConfigurationSection, IConfiguration
    {
        private Configuration()
        {
        }

        [ConfigurationProperty(Constants.CONFIG_RESOURCEID, IsRequired = true)]
        public string ResourceName
        {
            get { return (string) this[Constants.CONFIG_RESOURCEID]; }
            set { this[Constants.CONFIG_RESOURCEID] = value; }
        }

        [ConfigurationProperty(Constants.CONFIG_TIMEOUT_INSECS, IsRequired = true)]
        public string AuthTimeout
        {
            get { return (string)this[Constants.CONFIG_TIMEOUT_INSECS]; }
            set { this[Constants.CONFIG_TIMEOUT_INSECS] = value; }
        }

        [ConfigurationProperty(Constants.CONFIG_SERVERENDPOINT, IsRequired = true)]
        public string ServerEndpoint
        {
            get { return (string)this[Constants.CONFIG_SERVERENDPOINT]; }
            set { this[Constants.CONFIG_SERVERENDPOINT] = value; }
        }

        public static Configuration Load()
        {
            return
                ConfigurationManager.GetSection(Constants.CONFIG_SECTION) as
                    Configuration;
        }
    }
}
