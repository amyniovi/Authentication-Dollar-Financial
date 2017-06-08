using System.Configuration;

namespace Dollar.Authentication.Data.Configuration
{
    public class MongoDbConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("database", IsRequired = true)]
        public string Database
        {
            get { return (string) this["database"]; }
            set { this["database"] = value; }
        }

        [ConfigurationProperty("connectionString", IsRequired = true)]
        public string ConnectionString
        {
            get { return (string) this["connectionString"]; }
            set { this["connectionString"] = value; }
        }

        public static MongoDbConfiguration Load()
        {
            return
                ConfigurationManager.GetSection(string.Format("{0}/mongoDb", "authenticationService")) as
                    MongoDbConfiguration;
        }
    }
}