using Dollar.Authentication.Data.Models;
using Dollar.Authentication.Data.Models.Extensions;
using Dollar.Authentication.Domain;
using System;
using Xunit;

namespace Dollar.Authentication.Data.Tests.Models.Extensions
{
    public class PasswordExtensionsTests
    {
        [Fact]
        public void ToDomain_ValidEntity_HashMappedCorrectly()
        {
            // Arrange
            var expected = new PasswordModel
            {
                Hash = "32CA9FC1A0F5B6330E3F4C8C1BBECDE9BEDB9573",
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Hash, actual.Hash);
        }

        [Fact]
        public void ToDomain_ValidEntity_SaltMappedCorrectly()
        {
            // Arrange
            var expected = new PasswordModel
            {
                Salt = "Salt",
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Salt, actual.Salt);
        }

        [Fact]
        public void ToDomain_ValidEntity_VersionMappedCorrectly()
        {
            // Arrange
            var expected = new PasswordModel
            {
                Version = "Assembly.Namespace.Type, Assembly",
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Version, actual.Version);
        }

        [Fact]
        public void ToDomain_ValidEntity_CreatedOnMappedCorrectly()
        {
            // Arrange
            var expected = new PasswordModel
            {
                CreatedOn = new DateTime(2014, 11, 03, 12, 30, 00)
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
        }

        [Fact]
        public void ToModel_ValidEntity_HashMappedCorrectly()
        {
            // Arrange
            var expected = new Password
            {
                Hash = "32CA9FC1A0F5B6330E3F4C8C1BBECDE9BEDB9573",
            };

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Hash, actual.Hash);
        }

        [Fact]
        public void ToModel_ValidEntity_SaltMappedCorrectly()
        {
            // Arrange
            var expected = new Password
            {
                Salt = "Salt",
            };

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Salt, actual.Salt);
        }

        [Fact]
        public void ToModel_ValidEntity_VersionMappedCorrectly()
        {
            // Arrange
            var expected = new Password
            {
                CreatedOn = new DateTime(2014, 11, 03, 12, 30, 00)
            };

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Version, actual.Version);
        }

        [Fact]
        public void ToModel_ValidEntity_CreatedOnMappedCorrectly()
        {
            // Arrange
            var expected = new Password
            {
                CreatedOn = new DateTime(2014, 11, 03, 12, 30, 00)
            };

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
        }
    }
}