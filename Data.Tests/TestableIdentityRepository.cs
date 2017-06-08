using Dollar.Authentication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dollar.Authentication.Data.Tests
{
    public class TestableIdentityRepository : IdentityRepository
    {
        public static TestableIdentityRepository Create()
        {
            var repository = new TestableIdentityRepository();
            repository.DeleteTestIdentities();
            return repository;
        }

        public void DeleteTestIdentities()
        {
            var identitiesToDelete = GetAll()
                .ToList();

            identitiesToDelete.ForEach(Delete);
        }

        public Identity PersistNewValidIdentity()
        {
            var identity = new Identity
            {
                ResourceName = "MEM Account Management",
                UserId = "test@test.com",
                LastSuccessfulLogin = new DateTime(2014, 07, 01, 12, 30, 00).ToUniversalTime(),
                AccountLocked = true,
                CreatedOn = new DateTime(2013, 11, 01, 12, 00, 00),
                FailedLoginAttempts = new List<DateTime>
                {
                    new DateTime(2014, 11, 02, 12, 30, 00)
                },
                Passwords = new List<Password>
                {
                    new Password
                    {
                        Hash = "FD3F9CD44485D077836D25EA31E8B3D1F537A8BC",
                        Salt = "salt",
                        Version =
                            "Authentication.Services.Hashing.Sh1Hasher, Authentication.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        CreatedOn = new DateTime(2014, 11, 03, 12, 30, 00)
                    }
                },
                SecurityChecks = new List<SecurityCheck>
                {
                    new SecurityCheck("DateOfBirth", "01/02/1970")
                    {
                        CreatedOn = new DateTime(2014, 11, 04, 12, 40, 00)
                    }
                }
            };

            Save(identity);
            return identity;
        }
    }
}