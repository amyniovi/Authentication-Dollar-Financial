using Dollar.Authentication.Domain;
using System;
using System.Collections.Generic;

namespace Dollar.Authentication.Data
{
    public interface IIdentityRepository
    {
        IEnumerable<Identity> GetAll();
        void Save(Identity identity);
        void Delete(Identity identity);
        void Delete(Guid id);
        Identity GetById(Guid id);
        Identity GetByResourceAndUserId(string resourceName, string userId);
        IEnumerable<Identity> GetByResource(string resourceName);
    }
}