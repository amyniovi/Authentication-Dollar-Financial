using System;
using System.Collections.Generic;
using System.Security.Claims;
using Client.Tests.Fakes;
using Dollar.Authentication.Common;
using NUnit.Framework;

namespace Client.Tests
{
    [TestFixture]
    public class ApiClientTests
    {
        private readonly List<Claim> _emptyclaims = new List<Claim>();
        private const List<Claim> NullClaims = null;
        private PartialMockApiClient _apiClientPartialMock;
        private readonly List<Claim> _noPasswordClaims = new List<Claim> { new Claim(AuthUri.UserIdentifierUri(TestConstants.ResourceName).ToString(), TestConstants.ValidUsername) };
        private readonly List<Claim> _noUsernameClaims = new List<Claim> { new Claim(AuthUri.PasswordUri(TestConstants.ResourceName).ToString(), TestConstants.ValidPassword) };

        private readonly List<Claim> _validClaims = new List<Claim>
        {
            new Claim(AuthUri.UserIdentifierUri(TestConstants.ResourceName).ToString(), TestConstants.ValidUsername),
            new Claim(AuthUri.PasswordUri(TestConstants.ResourceName).ToString(), TestConstants.ValidPassword)
        };
      
        [Test]
        public void RequestAuthentication_WhenNullClaims_ExpectException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(NullClaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_WhenEmptyClaims_ExpectException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_emptyclaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_WhenEmptyResource_ExpectException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_emptyclaims), ResourceName = string.Empty };
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_WhenNullResource_ExpectException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_emptyclaims), ResourceName = null };
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_WhenPasswordClaimMissing_ExpectException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_noPasswordClaims), ResourceName = string.Empty };
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_WhenUsernameClaimMissing_ExpectException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_noUsernameClaims), ResourceName = string.Empty };
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_whenRequestValid_SendAsyncIsCalledOnce()
        {
            var authRequest = new AuthRequest{Identity = new ClaimsIdentity(_validClaims),ResourceName = TestConstants.ResourceName};
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            _apiClientPartialMock.RequestAuthorization(authRequest);

            Assert.IsTrue(_apiClientPartialMock.DelegatingHandler.SendAsyncIsCalled);
            Assert.IsTrue(_apiClientPartialMock.DelegatingHandler.SendAsyncCallCount == 1);
        }

        [Test]
        public void RequestAuthentication_whenRequestValid_ResponseIsAuthenticated()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_validClaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeSuccessHandler());

            var validationResponse = _apiClientPartialMock.RequestAuthorization(authRequest);
            Assert.IsTrue(validationResponse.IsAuthorized());
        }

        [Test]
        public void RequestAuthentication_whenRequestValidButRespondTakesLongerThanClientTimeOut_ThrowsException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_validClaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeClientTimeoutHandler());
           
             Assert.Throws<Exception>(()=> _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_whenRequestValidButTheServerReturnsANonSuccesfulResponse_ThrowsException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_validClaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeInternalServerErrorHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_whenRequestValidButTheServerReturnsNullResponse_ThrowsException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_validClaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeNullResponseHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_whenRequestValidButTheServerReturnsNullContentResponse_ThrowsException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_validClaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeNullResponseContentHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }

        [Test]
        public void RequestAuthentication_whenRequestValidButTheServerLeaksException_ThrowsException()
        {
            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(_validClaims), ResourceName = TestConstants.ResourceName };
            _apiClientPartialMock = new PartialMockApiClient(new FakeExceptionLeakHandler());

            Assert.Throws<Exception>(() => _apiClientPartialMock.RequestAuthorization(authRequest));
        }
 
        [TearDown]
        public void TearDown()
        {
            _apiClientPartialMock.Dispose();
        }
    }
}
