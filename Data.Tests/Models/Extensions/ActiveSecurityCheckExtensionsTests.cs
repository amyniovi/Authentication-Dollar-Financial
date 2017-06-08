using Dollar.Authentication.Data.Models;
using Dollar.Authentication.Data.Models.Extensions;
using Dollar.Authentication.Domain;
using System;
using Xunit;

namespace Dollar.Authentication.Data.Tests.Models.Extensions
{
    public class ActiveSecurityCheckExtensionTests
    {
        [Fact]
        public void ToDomain_ValidEntity_KeyMappedCorrectly()
        {
            // Arrange
            var expected = new ActiveSecurityCheckModel
            {
                Key = "DateOfBirth",
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Key, actual.Key);
        }

        [Fact]
        public void ToDomain_ValidEntity_CreatedOnMappedCorrectly()
        {
            // Arrange
            var expected = new ActiveSecurityCheckModel
            {
                CreatedOn = new DateTime(2013, 01, 01, 11, 00, 00).ToUniversalTime()
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
        }

        [Fact]
        public void ToModel_ValidEntity_KeyMappedCorrectly()
        {
            // Arrange
            var expected = new ActiveSecurityCheck
            {
                Key = "DateOfBirth",
            };

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Key, actual.Key);
        }

        [Fact]
        public void ToModel_ValidEntity_CreatedOnMappedCorrectly()
        {
            // Arrange
            var expected = new ActiveSecurityCheck
            {
                CreatedOn = new DateTime(2013, 01, 01, 11, 00, 00).ToUniversalTime()
            };

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
        }
    }
}