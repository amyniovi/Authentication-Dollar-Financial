using Dollar.Authentication.Services.Hashing.Sh1;
using Xunit;

namespace Dollar.Authentication.Services.Tests.Hashing.Sh1
{
    public class Sh1HasherTests
    {
        [Fact]
        public void GetHash_ValidInput_CorrectHashReturned()
        {
            // Arrange
            const string expected = "FD3F9CD44485D077836D25EA31E8B3D1F537A8BC";
            var hasher = new Sh1Hasher();

            // Act
            string actual = hasher.GetHash("Password1!", "salt");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}