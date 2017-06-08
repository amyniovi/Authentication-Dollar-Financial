using Dollar.Authentication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dollar.Authentication.Data.Tests
{
    public class TestableResourceRepository : ResourceRepository
    {
        public static TestableResourceRepository Create()
        {
            var repository = new TestableResourceRepository();
            repository.DeleteTestIdentities();
            return repository;
        }

        public void DeleteTestIdentities()
        {
            var identitiesToDelete = GetAll()
                .ToList();

            identitiesToDelete.ForEach(Delete);
        }

        public Resource PersistNewValidIdentity()
        {
            var resource = new Resource
            {
                Name = "MEM Account Management",
                MaximumFailedLoginAttempts = 4,
                ActiveSecurityChecks = new List<ActiveSecurityCheck>
                {
                    new ActiveSecurityCheck
                    {
                        Key = "DateOfBirth",
                        CreatedOn = new DateTime(2013, 01, 01, 11, 00, 00).ToUniversalTime()
                    }
                }
            };

            Save(resource);
            return resource;
        }
    }
}