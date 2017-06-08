using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Dollar.Authentication.Common;

namespace Client.Tests.Fakes
{
    public class FakeSuccessHandler : FakeDelegatingHandlerBase
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SendAsyncIsCalled = true;
            SendAsyncCallCount++;

            var content = new ValidationResponse { IsPasswordCorrect = true, IsUserIdentifierFound = true, IsUserUnlocked = true };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<ValidationResponse>(content,new JsonMediaTypeFormatter())
            };

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
