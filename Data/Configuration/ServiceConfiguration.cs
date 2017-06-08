using System.Configuration;

namespace Dollar.Authentication.Data.Configuration
{
    public class ServiceConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }

        public static ServiceConfiguration Load()
        {
            return ConfigurationManager.GetSection("authenticationService/service") as ServiceConfiguration;
        }
    }
}