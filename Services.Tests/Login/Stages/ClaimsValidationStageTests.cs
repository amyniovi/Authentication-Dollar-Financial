using System;
using System.Collections.Generic;
using System.Security.Claims;
using Dollar.Authentication.Common;
using Dollar.Authentication.Domain;
using Dollar.Authentication.Services.Login;
using Dollar.Authentication.Services.Login.Stages;
using Xunit;

namespace Dollar.Authentication.Services.Tests.Login.Stages
{
    public class ClaimsValidationStageTests
    {
        [Fact]
        public void Validate_ContextIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            const string expected = "LoginContext is null";
            var claimsValidationStage = new ClaimsValidationStage();

            // Act
            var actual = Assert.Throws<ArgumentNullException>(() => claimsValidationStage.Validate(null)).Message;

            // Assert
            Assert.Contains(expected, actual);
        }

        [Fact]
        public void Validate_ContextContainsNullStoredIdentity_ThrowsArgumentException()
        {
            // Arrange
            const string expected = "LoginContext contains a null StoredIdentity";
            var claimsValidationStage = new ClaimsValidationStage();
            var loginContext = new LoginContext
            {
                Request = new AuthRequest(),
                StoredIdentity = null
            };

            // Act
            var actual = Assert.Throws<ArgumentException>(() => claimsValidationStage.Validate(loginContext)).Message;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Validate_ContextContainsNullRequest_ThrowsArgumentException()
        {
            // Arrange
            const string expected = "LoginContext contains a null Request";
            var claimsValidationStage = new ClaimsValidationStage();
            var loginContext = new LoginContext
            {
                Request = null,
                StoredIdentity = new Identity()
            };

            // Act
            var actual = Assert.Throws<ArgumentException>(() => claimsValidationStage.Validate(loginContext)).Message;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Validate_IncomingRequestDoesNotContainCorrectSecurityCheckType_ReturnsFalse()
        {
            var claimsValidationStage = new ClaimsValidationStage();
            var loginContext = new LoginContext
            {
                Request = new AuthRequest
                {
                    Identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim("ExpectedType", "ExpectedValue")
                    })

                },
                StoredIdentity = new Identity
                {
                    SecurityChecks = new List<SecurityCheck>
                    {
                        new SecurityCheck("WrongType", "ExpectedValue")
                    }
                }
            };

            // Act
            var actual = claimsValidationStage.Validate(loginContext);

            // Assert
            Assert.False(actual);
        }


        [Fact]
        public void Validate_IncomingRequestDoesNotContainCorrectSecurityCheckValue_ReturnsFalse()
        {
            var claimsValidationStage = new ClaimsValidationStage();
            var loginContext = new LoginContext
            {
                Request = new AuthRequest
                {
                    Identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim("ExpectedType", "ExpectedValue")
                    })

                },
                StoredIdentity = new Identity
                {
                    SecurityChecks = new List<SecurityCheck>
                    {
                        new SecurityCheck("ExpectedType","WrongValue")
                    }
                }
            };

            // Act
            var actual = claimsValidationStage.Validate(loginContext);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void Validate_IncomingRequestContainsPartiallyCorrectSecurityCheck_ReturnsFalse()
        {
            var claimsValidationStage = new ClaimsValidationStage();
            var loginContext = new LoginContext
            {
                Request = new AuthRequest
                {
                    Identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim("ExpectedType1", "ExpectedValue1"),
                        new Claim("ExpectedType2", "ExpectedValue1"),
                    })

                },
                StoredIdentity = new Identity
                {
                    SecurityChecks = new List<SecurityCheck>
                    {
                        new SecurityCheck("ExpectedType1", "ExpectedValue1"),
                        new SecurityCheck("Wrong", "Wrong")
                    }
                }
            };

            // Act
            var actual = claimsValidationStage.Validate(loginContext);

            // Assert
            Assert.False(actual);
        }


        [Fact]
        public void Validate_IncomingRequestContainsCorrectSecurityCheck_ReturnsTrue()
        {
            var claimsValidationStage = new ClaimsValidationStage();
            var loginContext = new LoginContext
            {
                Request = new AuthRequest
                {
                    Identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim("ExpectedType1", "ExpectedValue1"),
                        new Claim("ExpectedType2", "ExpectedValue2")
                    })

                },
                StoredIdentity = new Identity
                {
                    SecurityChecks = new List<SecurityCheck>
                    {
                        new SecurityCheck("ExpectedType1", "ExpectedValue1"),
                        new SecurityCheck("ExpectedType2", "ExpectedValue2")
                    }
                }
            };

            // Act
            var actual = claimsValidationStage.Validate(loginContext);

            // Assert
            Assert.True(actual);
        }
    }
}
