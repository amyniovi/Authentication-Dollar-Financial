using Dollar.Authentication.Services.Hashing.Sh1;
using System;
using Xunit;

namespace Dollar.Authentication.Services.Tests.Hashing
{
    public class HasherBaseTests
    {
        [Fact]
        public void GetHash_NullValueSupplied_ThrowsArgumentNullException()
        {
            // Arrange
            var hasher = new Sh1Hasher();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => hasher.GetHash(null, "salt"));
        }

        [Fact]
        public void GetHash_EmptyValueSupplied_ThrowsArgumentNullException()
        {
            // Arrange
            var hasher = new Sh1Hasher();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => hasher.GetHash("", "salt"));
        }

        [Fact]
        public void GetHash_NullVSaltSupplied_ThrowsArgumentNullException()
        {
            // Arrange
            var hasher = new Sh1Hasher();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => hasher.GetHash("hash", null));
        }

        [Fact]
        public void GetHash_EmptySaltSupplied_ThrowsArgumentNullException()
        {
            // Arrange
            var hasher = new Sh1Hasher();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => hasher.GetHash("salt", null));
        }
    }
}