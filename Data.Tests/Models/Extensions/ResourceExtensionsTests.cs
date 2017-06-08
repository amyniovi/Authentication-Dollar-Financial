using Dollar.Authentication.Data.Models;
using Dollar.Authentication.Data.Models.Extensions;
using Dollar.Authentication.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Dollar.Authentication.Data.Tests.Models.Extensions
{
    public class ResourceExtensionsTests
    {
        [Fact]
        public void ToDomain_ValidEntity_IdMappedCorrectly()
        {
            // Arrange
            ResourceModel expected = CreateResourceModel();

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Id, actual.Id.ToString());
        }

        [Fact]
        public void ToDomain_ValidEntity_NameMappedCorrectly()
        {
            // Arrange
            ResourceModel expected = CreateResourceModel();

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void ToModel_ValidEntity_IdMappedCorrectly()
        {
            // Arrange
            var expected = CreateResource();

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Id.ToString(), actual.Id);
        }

        [Fact]
        public void ToModel_ValidEntity_NameMappedCorrectly()
        {
            // Arrange
            var expected = CreateResource();

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Name, actual.Name);
        }

        private ResourceModel CreateResourceModel()
        {
            return new ResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "MEM Account Management",
                MaximumFailedLoginAttempts = 4,
                ActiveSecurityChecks = new List<ActiveSecurityCheckModel>
                {
                    new ActiveSecurityCheckModel
                    {
                        Key = "DateOfBirth",
                        CreatedOn = new DateTime(2013, 01, 01, 11, 00, 00).ToUniversalTime()
                    }
                }
            };
        }

        private Resource CreateResource()
        {
            return new Resource
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
        }
    }
}