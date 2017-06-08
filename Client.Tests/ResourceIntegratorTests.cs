using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Client.Tests.Fakes;
using Dollar.Authentication.Client.ResourceIntegration;
using Dollar.Authentication.Common;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Client.Tests
{
    [TestFixture]
    public class ResourceIntegratorTests
    {
        private Dictionary<string, string> _securityChecks = new Dictionary<string, string>();

        [Test]
        [TestCase(null, TestConstants.ValidPassword)]
        [TestCase("", TestConstants.ValidPassword)]
        [TestCase(" ", TestConstants.ValidPassword)]
        [TestCase(TestConstants.ValidUsername, null)]
        [TestCase(TestConstants.ValidUsername, "")]
        [TestCase(TestConstants.ValidUsername, " ")]
        [TestCase("", "")]
        [TestCase(" ", " ")]
        [TestCase(null, null)]
        public void Login_WithNoPasswordOrUsername_ThrowsException(string username, string password)
        {
            var apiClientMock = new PartialMockApiClient();
            var resourceIntegrator = new ResourceIntegrator(apiClientMock);

            Assert.Throws<ArgumentNullException>(() => resourceIntegrator.Login(username, password));
        }

        [Test]
        public void Login_withUsernameAndPasswordProvidedButNoSecurityChecks_RequestAuthenticationIsCalled()
        {
            var apiClientMock = new FullMockApiClient();
            var resourceIntegrator = new ResourceIntegrator(apiClientMock);
            resourceIntegrator.Login(TestConstants.ValidUsername, TestConstants.ValidPassword);
            Assert.IsTrue(apiClientMock.IsRequestAuthorizationCalled);
        }

        [Test]
        public void Login_withNoResourceName_ThrowsException()
        {
            var apiClientMock = new FullMockApiClient(true);
            var resourceIntegrator = new ResourceIntegrator(apiClientMock);

            Assert.Throws<Exception>(() => resourceIntegrator.Login(TestConstants.ValidUsername, TestConstants.ValidPassword),
                Constants.GENERIC_NORESOURCE_ERROR);
        }

        [Test]
        public void Login_withSecurityChecksX_AuthRequestContainsClaimsX()
        {
            var apiClientMock = new FullMockApiClient();
            var config = new FakeConfiguration();
            var resourceIntegrator = new ResourceIntegrator(apiClientMock);
            _securityChecks.Add("postcode", "W10PJ2");
            _securityChecks.Add("role", "dev");
            resourceIntegrator.Login(TestConstants.ValidUsername, TestConstants.ValidPassword, _securityChecks);
            Assert.IsTrue(
                _securityChecks.ToList()
                    .Exists(
                        check =>
                            apiClientMock.AuthorizationRequestCreated.Identity.HasClaim(
                                c => c.Type == new AuthUri(config.ResourceName, check.Key).ToString() && c.Value == check.Value)));
        }
    }
}
