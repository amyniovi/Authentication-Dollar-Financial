using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Dollar.Authentication.Client;
using Dollar.Authentication.Common;

namespace Client.Tests.Fakes
{
    public class PartialMockApiClient : ApiClient, IDisposable
    {
        public FakeDelegatingHandlerBase DelegatingHandler { get; private set; }
        public bool IsRequestAuthorizationCalled { get; private set; }

        public PartialMockApiClient(FakeDelegatingHandlerBase delegatingHandler = null, bool nullConfigurationValue = false)
            : base(new FakeConfiguration(nullConfigurationValue))
        {
            DelegatingHandler = delegatingHandler;
        }

        public override ValidationResponse RequestAuthorization(AuthRequest authRequest)
        {
            IsRequestAuthorizationCalled = true;
            return base.RequestAuthorization(authRequest);
        }

        protected override HttpClient BuildSecureHttpClient()
        {
            //we dont want a singleton HttpClient for the Tests
            //we need to instantiate a new client for every ApiClientMock with a different DelegatingHandler depending on the request.
            //we also need to dispose of those ApiClients.
            var client = HttpClientFactory.Create(DelegatingHandler);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Configuration.ServerEndpoint.Contains("https") ? Configuration.ServerEndpoint : Configuration.ServerEndpoint.Replace("http", "https"));
            return client;
        }

        public void Dispose()
        {
            if (HttpClient == null)
                return;
            HttpClient.Dispose();
        }
    }
}
