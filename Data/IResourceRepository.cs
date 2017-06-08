using Dollar.Authentication.Domain;
using System;
using System.Collections.Generic;

namespace Dollar.Authentication.Data
{
    public interface IResourceRepository
    {
        IEnumerable<Resource> GetAll();
        void Save(Resource identity);
        Resource GetById(Guid id);
        Resource GetByName(string name);
        void Delete(Resource resource);
        void Delete(Guid id);
    }
}