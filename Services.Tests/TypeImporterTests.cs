using Dollar.Authentication.Services.Hashing;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Dollar.Authentication.Services.Tests
{
    public class TypeImporterTests
    {
        [Fact]
        public void GetHashers_IHasherExistsInAssembly_CorrectHasherReturned()
        {
            // Arrange
            var hasherImporter = new TypeImporter<IHasher>();
            var assemblyName = Assembly.GetExecutingAssembly().ToString();

            // Act
            var actual = hasherImporter.GetImports()
                .First(
                    assembly =>
                        assembly.Value.GetType().Assembly.FullName ==
                        assemblyName)
                .Value;

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(actual.GetType(), typeof (FakeHasher));
        }

        /// <summary>
        ///     Fake class is used for 'GetHashers_IHasherExistsInAssembly_CorrectHasherReturned' test.
        /// </summary>
        private class FakeHasher : IHasher
        {
            public string GetHash(string value, string salt)
            {
                throw new NotImplementedException();
            }
        }
    }
}