using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Dollar.Authentication.Common;

namespace Client.Tests.Fakes
{
    /// <summary>
    /// Simulates the content of the server response being null.
    /// </summary>
    internal class FakeNullResponseContentHandler : FakeDelegatingHandlerBase
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SendAsyncIsCalled = true;
            SendAsyncCallCount++;

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<ValidationResponse>(null, new JsonMediaTypeFormatter())
            };

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;             
        }
    }
}
