
using System.Net.Http;

namespace Client.Tests.Fakes
{
    public class FakeDelegatingHandlerBase : DelegatingHandler
    {
        public bool SendAsyncIsCalled { get; protected set; }
        public int SendAsyncCallCount { get; protected set; }
    }
}
