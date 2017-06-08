using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Tests.Fakes
{
    public class FakeExceptionLeakHandler : FakeDelegatingHandlerBase
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SendAsyncIsCalled = true;
            SendAsyncCallCount++;
           
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetException(new Exception());
            return tsc.Task;
        }
    }
}
