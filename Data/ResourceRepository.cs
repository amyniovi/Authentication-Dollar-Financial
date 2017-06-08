using Dollar.Authentication.Data.Models;
using Dollar.Authentication.Data.Models.Extensions;
using Dollar.Authentication.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dollar.Authentication.Data
{
    public class ResourceRepository : MongoDbRepositoryBase, IResourceRepository
    {
        private MongoCollection<ResourceModel> Resources
        {
            get { return GetCollection<ResourceModel>("authentication_resource"); }
        }

        public IEnumerable<Resource> GetAll()
        {
            var resources = Resources.FindAll()
                .Select(resource => resource.ToDomain());

            return resources;
        }

        public void Save(Resource identity)
        {
            var resourceModel = identity.ToModel();
            Resources.Save(resourceModel);
        }

        public Resource GetById(Guid id)
        {
            return Resources
                .AsQueryable()
                .SingleOrDefault(resource => resource.Id == id.ToString())
                .ToDomain();
        }

        public Resource GetByName(string name)
        {
            return Resources
                .AsQueryable()
                .SingleOrDefault(resource => resource.Name == name)
                .ToDomain();
        }

        public void Delete(Resource resource)
        {
            Delete(resource.Id);
        }

        public void Delete(Guid id)
        {
            IMongoQuery query = Query<IdentityModel>.Where(resourceModel => resourceModel.Id == id.ToString());
            Resources.Remove(query);
        }
    }
}