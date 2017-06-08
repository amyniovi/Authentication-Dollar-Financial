using Dollar.Authentication.Services.Hashing.Sh1;
using Xunit;

namespace Dollar.Authentication.Services.Tests.Hashing.Sh1
{
    public class Sh1SaltMixHasherTests
    {
        [Fact]
        public void GetHash_ValidInput_CorrectHashReturned()
        {
            // Arrange
            const string expected = "6D963721AA323AB59536B5A6C33AEDE502F421EE";
            var hasher = new Sh1SaltMixHasher();

            // Act
            string actual = hasher.GetHash("Password1!", "salt");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}