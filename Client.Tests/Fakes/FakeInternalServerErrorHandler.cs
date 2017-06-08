using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Dollar.Authentication.Common;

namespace Client.Tests.Fakes
{
    /// <summary>
    /// Simulates a non-Succesful response from the server which should throw an exception on the client.
    /// whether the validationResponse is authenticated or not is irrelevant.
    /// </summary>
    public class FakeInternalServerErrorHandler : FakeDelegatingHandlerBase
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            SendAsyncIsCalled = true;
            SendAsyncCallCount++;

            var content = new ValidationResponse { IsPasswordCorrect = true, IsUserIdentifierFound = true, IsUserUnlocked = true };
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent<ValidationResponse>(content, new JsonMediaTypeFormatter())
            };

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
