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
    public class IdentityRepository : MongoDbRepositoryBase, IIdentityRepository
    {
        private MongoCollection<IdentityModel> Identities
        {
            get { return GetCollection<IdentityModel>("authentication_identity"); }
        }

        public IEnumerable<Identity> GetAll()
        {
            var identities = Identities.FindAll()
                .Select(identity => identity.ToDomain());

            return identities;
        }

        public void Save(Identity identity)
        {
            var identityModel = identity.ToModel();
            Identities.Save(identityModel);
        }

        public Identity GetById(Guid id)
        {
            return Identities
                .AsQueryable()
                .SingleOrDefault(identity => identity.Id == id.ToString())
                .ToDomain();
        }

        public Identity GetByResourceAndUserId(string resourceName, string userId)
        {
            return Identities
                .AsQueryable()
                .SingleOrDefault(identity => identity.ResourceName == resourceName &&
                                             identity.UserId == userId)
                .ToDomain();
        }

        public IEnumerable<Identity> GetByResource(string resourceName)
        {
            return Identities
                .AsQueryable()
                .Where(identity => identity.ResourceName == resourceName)
                .Select(identity => identity.ToDomain());
        }

        public void Delete(Identity identity)
        {
            Delete(identity.Id);
        }

        public void Delete(Guid id)
        {
            IMongoQuery query = Query<IdentityModel>.Where(identityModel => identityModel.Id == id.ToString());
            Identities.Remove(query);
        }
    }
}