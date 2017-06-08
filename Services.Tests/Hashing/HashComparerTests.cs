using Dollar.Authentication.Domain;
using Dollar.Authentication.Services.Hashing;
using System;
using System.Collections.Generic;
using Dollar.Authentication.Services.Hashing.Sh1;
using Xunit;

namespace Dollar.Authentication.Services.Tests.Hashing
{
    public class HashComparerTests
    {
        [Fact]
        public void Compare_MatchingPassword_ReturnsTrue()
        {
            // Arrange
            var version = typeof(Sh1Hasher).AssemblyQualifiedName;
            var password = new Password
            {
                Hash = "FD3F9CD44485D077836D25EA31E8B3D1F537A8BC",
                Salt = "salt",
                Version = version
            };

            var hasherImporter = new HasherImporter();
            var hashers = hasherImporter.GetImports();
            var hashComparer = new HashComparer(hashers);

            // Act
            var actual = hashComparer.Compare("Password1!", password);

            // Asert
            Assert.True(actual);
        }

        [Fact]
        public void Compare_NonMatchingPassword_ReturnsFalse()
        {
            // Arrange
            var version = typeof(Sh1Hasher).AssemblyQualifiedName;
            var password = new Password
            {
                Hash = "FD3F9CD44485D077836D25EA31E8B3D1F537A8BC",
                Salt = "salt",
                Version = version
            };

            var hasherImporter = new HasherImporter();
            var hashers = hasherImporter.GetImports();
            var hashComparer = new HashComparer(hashers);

            // Act
            var actual = hashComparer.Compare("password", password);

            // Asert
            Assert.False(actual);
        }
    }
}