using Dollar.Authentication.Data.Models;
using Dollar.Authentication.Data.Models.Extensions;
using Dollar.Authentication.Domain;
using System;
using Xunit;

namespace Dollar.Authentication.Data.Tests.Models.Extensions
{
    public class SecurityCheckExtensionsTests
    {
        [Fact]
        public void ToDomain_ValidEntity_KeyMappedCorrectly()
        {
            // Arrange
            var expected = new SecurityCheckModel
            {
                Key = "DateOfBirth",
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Key, actual.Key);
        }

        [Fact]
        public void ToDomain_ValidEntity_ValueMappedCorrectly()
        {
            // Arrange
            var expected = new SecurityCheckModel
            {
                Value = "01/02/1970",
            };

            // Act
            var actual = expected.ToDomain();

            // Assert
            Assert.Equal(expected.Value, actual.Value);
        }

        [Fact]
        public void ToDomain_ValidEntity_CreatedOnMappedCorrectly()
        {
            // Arrange
            var expected = new SecurityCheckModel
            {
                CreatedOn = new DateTime(2014, 11, 04, 12, 40, 00)
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
            var expected = new SecurityCheck("DateOfBirth", null);

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Key, actual.Key);
        }

        [Fact]
        public void ToModel_ValidEntity_ValueMappedCorrectly()
        {
            // Arrange
            var expected = new SecurityCheck(null, "01/02/1970");

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.Value, actual.Value);
        }

        [Fact]
        public void ToModel_ValidEntity_CreatedOnMappedCorrectly()
        {
            // Arrange
            var expected = new SecurityCheck(null, null)
            {
                CreatedOn = new DateTime(2014, 11, 04, 12, 40, 00)
            };

            // Act
            var actual = expected.ToModel();

            // Assert
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
        }
    }
}