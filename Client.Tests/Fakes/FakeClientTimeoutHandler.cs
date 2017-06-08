using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Tests.Fakes
{
    /// <summary>
    /// We are using an asynchronous method SendAsync synchronously which means it would block until the server responds.
    /// Setting a timeout on the client of 4secs means in 4secs the client will stop waiting for this Task that executes SendAsync
    /// The task will still be running and will not have a status of TaskStatus.RanToCompletion.
    /// To simulate this we return a task that doesnt have a status of RanToCompletion which will mean the client will wait upon reading the response as the Result of the task wont be set.
    /// todo: cancel the tasks that are taking too long on client or just have a time out on server
    /// </summary>
    public class FakeClientTimeoutHandler : FakeDelegatingHandlerBase 
    {
            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                SendAsyncIsCalled = true;
                SendAsyncCallCount++;
           
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                //task status will be WaitingForActivation as we dont call SetResult
                //we are returning a task that is not completed indicating it is taking a long time.
                return tsc.Task;
            }
    }
}
