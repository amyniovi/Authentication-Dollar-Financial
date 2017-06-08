using System;
using System.Net.Http;

namespace Dollar.Authentication.Client
{
    public class HttpClientInstance : HttpClient
    {
        //Thread safe version
        private static readonly Lazy<HttpClient> LazyHttpClient =
            new Lazy<HttpClient>(() => HttpClientFactory.Create( _handlers), true);

        private static DelegatingHandler[] _handlers;
        private HttpClientInstance()
        {
        }

        public static HttpClient GetInstance(params DelegatingHandler[] handlers)
        {
            _handlers = handlers;
            return LazyHttpClient.Value;
        }
    }
}