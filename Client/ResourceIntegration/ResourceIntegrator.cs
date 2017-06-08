using Dollar.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using Dollar.Authentication.Client;

namespace Dollar.Authentication.Client.ResourceIntegration
{
    public class ResourceIntegrator
    {
        private IApiClient _apiClient;
        private static readonly IConfiguration WebConfig = Configuration.Load();

        public ResourceIntegrator(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public ValidationResponse Login(string username, string password, Dictionary<string, string> securityChecks = null)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username");
            }

            var resourceId = _apiClient.Configuration.ResourceName;

            if (string.IsNullOrWhiteSpace(resourceId))
            {
                throw new Exception(Constants.GENERIC_NORESOURCE_ERROR);
            }

            var claims = new List<Claim>
            {
                new Claim(AuthUri.UserIdentifierUri(resourceId).ToString(), username),
                new Claim(AuthUri.PasswordUri(resourceId).ToString(), password),
            };

            if (securityChecks != null && securityChecks.Any())
            {
                claims.AddRange(
                    securityChecks.Select(check => new Claim(new AuthUri(resourceId, check.Key).ToString(), check.Value)));
            }

            var authRequest = new AuthRequest { Identity = new ClaimsIdentity(claims), ResourceName = resourceId };
            //New up ApiClient as no dependency injection framework used.
            if (_apiClient == null)
                _apiClient = new ApiClient(WebConfig);

            return _apiClient.RequestAuthorization(authRequest);
        }
    }
}
