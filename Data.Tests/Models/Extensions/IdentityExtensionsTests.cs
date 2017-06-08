using Dollar.Authentication.Data.Models;
using Dollar.Authentication.Data.Models.Extensions;
using Dollar.Authentication.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Dollar.Authentication.Data.Tests.Models.Extensions
{
    public class IdentityExtensionsTests
    {
        [Fact]
        public void ToDomain_ValidEntity_IdMappedCorrectlyMapped()
        {
            // Act
            IdentityModel expected = CreateIdentityModel();

            // Arrange
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Id, actual.Id.ToString());
        }

        [Fact]
        public void ToDomain_ValidEntity_ResourceNameCorrectlyMapped()
        {
            // Act
            IdentityModel expected = CreateIdentityModel();

            // Arrange
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.ResourceName, actual.ResourceName);
        }

        [Fact]
        public void ToDomain_ValidEntity_UserICorrectlyMapped()
        {
            // Act
            IdentityModel expected = CreateIdentityModel();

            // Arrange
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.UserId, actual.UserId);
        }

        [Fact]
        public void ToDomain_ValidEntity_LastSuccessfulLoginCorrectlyMapped()
        {
            // Act
            IdentityModel expected = CreateIdentityModel();

            // Arrange
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.LastSuccessfulLogin, actual.LastSuccessfulLogin);
        }

        [Fact]
        public void ToDomain_ValidEntity_AccountLockedCorrectlyMapped()
        {
            // Act
            IdentityModel expected = CreateIdentityModel();

            // Arrange
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.AccountLocked, actual.AccountLocked);
        }

        [Fact]
        public void ToDomain_ValidEntity_CreatedOnCorrectlyMapped()
        {
            // Act
            IdentityModel expected = CreateIdentityModel();

            // Arrange
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
        }

        [Fact]
        public void ToModel_ValidEntity_IdMappedCorrectlyMapped()
        {
            // Act
            var expected = CreateIdentity();

            // Arrange
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Id.ToString(), actual.Id);
        }

        [Fact]
        public void ToModel_ValidEntity_ResourceNameCorrectlyMapped()
        {
            // Act
            var expected = CreateIdentity();

            // Arrange
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.ResourceName, actual.ResourceName);
        }

        [Fact]
        public void ToModel_ValidEntity_UserICorrectlyMapped()
        {
            // Act
            var expected = CreateIdentity();

            // Arrange
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.UserId, actual.UserId);
        }

        [Fact]
        public void ToModel_ValidEntity_LastSuccessfulLoginCorrectlyMapped()
        {
            // Act
            var expected = CreateIdentity();

            // Arrange
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.LastSuccessfulLogin, actual.LastSuccessfulLogin);
        }

        [Fact]
        public void ToModel_ValidEntity_AccountLockedCorrectlyMapped()
        {
            // Act
            var expected = CreateIdentity();

            // Arrange
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.AccountLocked, actual.AccountLocked);
        }

        [Fact]
        public void ToModel_ValidEntity_CreatedOnCorrectlyMapped()
        {
            // Act
            var expected = CreateIdentity();

            // Arrange
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
        }

        private IdentityModel CreateIdentityModel()
        {
            return new IdentityModel
            {
                Id = Guid.NewGuid().ToString(),
                ResourceName = "MEM Account Management",
                UserId = "test@test.com",
                LastSuccessfulLogin = new DateTime(2014, 07, 01, 12, 30, 00).ToUniversalTime(),
                AccountLocked = true,
                CreatedOn = new DateTime(2013, 11, 01, 12, 00, 00),
                FailedLoginAttempts = new List<DateTime>
                {
                    new DateTime(2014, 11, 02, 12, 30, 00)
                },
                Passwords = new List<PasswordModel>
                {
                    new PasswordModel
                    {
                        Hash = "32CA9FC1A0F5B6330E3F4C8C1BBECDE9BEDB9573",
                        Salt = "",
                        Version = "Assembly.Namespace.Type, Assembly",
                        CreatedOn = new DateTime(2014, 11, 03, 12, 30, 00)
                    }
                },
                SecurityChecks = new List<SecurityCheckModel>
                {
                    new SecurityCheckModel
                    {
                        Key = "DateOfBirth",
                        Value = "01/02/1970",
                        CreatedOn = new DateTime(2014, 11, 04, 12, 40, 00)
                    }
                }
            };
        }

        private Identity CreateIdentity()
        {
            return new Identity
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
                        Hash = "32CA9FC1A0F5B6330E3F4C8C1BBECDE9BEDB9573",
                        Salt = "",
                        Version = "Assembly.Namespace.Type, Assembly",
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
        }
    }
}