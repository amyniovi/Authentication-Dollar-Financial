using Dollar.Authentication.Data.Configuration;
using MongoDB.Driver;
using System;

namespace Dollar.Authentication.Data
{
    public abstract class MongoDbRepositoryBase
    {
        private static readonly Lazy<MongoDbConfiguration> MongoDbConfig =
            new Lazy<MongoDbConfiguration>(MongoDbConfiguration.Load);

        private static readonly Lazy<ServiceConfiguration> ServiceConfig =
            new Lazy<ServiceConfiguration>(ServiceConfiguration.Load);

        private readonly Lazy<MongoDatabase> _database = new Lazy<MongoDatabase>(GetDatabase);

        protected MongoCollection<T> GetCollection<T>(string collectionName)
        {
            string serviceConfigurationName = ServiceConfig.Value.Name;
            string fullCollectionName = string.Format("{0}.{1}", serviceConfigurationName, collectionName);
            return _database.Value.GetCollection<T>(fullCollectionName);
        }

        private static MongoDatabase GetDatabase()
        {
            return new MongoClient(MongoDbConfig.Value.ConnectionString)
                .GetServer()
                .GetDatabase(MongoDbConfig.Value.Database);
        }
    }
}