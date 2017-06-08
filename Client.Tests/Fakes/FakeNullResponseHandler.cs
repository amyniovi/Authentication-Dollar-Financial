using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Tests.Fakes
{
    /// <summary>
    /// Simulates the server returning null. 
    /// </summary>
    class FakeNullResponseHandler : FakeDelegatingHandlerBase
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SendAsyncIsCalled = true;
            SendAsyncCallCount++;

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(null);
            return tsc.Task;
        }
    }
}
