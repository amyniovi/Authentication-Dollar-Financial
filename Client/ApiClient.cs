using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Dollar.Authentication.Client.Globals;
using Dollar.Authentication.Common;
using Newtonsoft.Json;

namespace Dollar.Authentication.Client
{
    public class ApiClient : IApiClient
    {
        public IConfiguration Configuration { get; set; }
        protected HttpClient HttpClient { get; set; }

        public ApiClient(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual ValidationResponse RequestAuthorization(AuthRequest authRequest)
        {
            #region Guard clauses

            if (authRequest.Identity == null ||
                !authRequest.Identity.Claims.Any()
                )
            {
                throw new Exception(Constants.GENERIC_NOCLAIMS_ERROR);
            }

            if (string.IsNullOrWhiteSpace(authRequest.ResourceName))
            {
                throw new Exception(Constants.GENERIC_NORESOURCE_ERROR);
            }

            if (!authRequest.Identity.HasClaim(c => c.Type == AuthUri.PasswordUri(authRequest.ResourceName).ToString()) ||
                !authRequest.Identity.HasClaim(c => c.Type == AuthUri.UserIdentifierUri(authRequest.ResourceName).ToString()))
            {
                throw new Exception(Constants.GENERIC_NOPASSWORDORUSERNAME_ERROR);
            }

            #endregion

            HttpResponseMessage response;
            ValidationResponse validationResult = null;

            HttpClient = BuildSecureHttpClient();

            var requestMessage = BuildHttpRequestMessageWithContent(authRequest, HttpMethod.Post, Configuration.ServerEndpoint + GlobalResources.LoginUrl);

            //Task that posts the Login Request
            Task<HttpResponseMessage> taskCaptureResponse =
              HttpClient.SendAsync(
                  requestMessage, HttpCompletionOption.ResponseContentRead);

            var taskDeserializeResponse = taskCaptureResponse.ContinueWith(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                    return;
                response = t.Result;
                if (response != null && response.Content != null && response.IsSuccessStatusCode)
                {
                    validationResult = response.Content.ReadAsAsync<ValidationResponse>().Result;
                }
            });

            //using Task.WaitAll() instead of taskCaptureResponse.Wait(); ensures that
            //the Continuation (taskDeserializeResponse) is executed before the rest of the function after the WaitAll() statement.
            try
            {
                //TimeOut below, means tasks will be left unfinished if exceeded  
                //in which case the validationResult will not have been calculated correctly
                //so we need to throw an exception to determine the failure reason was in fact a time out.
                Task.WaitAll(new[] { taskCaptureResponse, taskDeserializeResponse },
                    Convert.ToInt16(Configuration.AuthTimeout));

                if (validationResult == null)
                    throw new Exception(Constants.GENERIC_APICOMMUNICATION_ERROR);
            }
            catch (AggregateException ae)
            {
                throw new Exception(Constants.GENERIC_APICOMMUNICATION_ERROR, ae.GetBaseException());
            }

            return validationResult;
        }

        /// <summary>
        /// Constructs the HttpRequest to send to the Api as a POST or PUT or DELETE or any request that contains an object in the body as JSON. 
        /// Get requests not handled here 
        /// </summary>
        /// <typeparam name="T"></typeparam> The type of the entity posted
        /// <param name="requestEntity"></param> The entity posted
        /// <param name="httpMethod"></param> The Http method type
        /// <param name="uri"></param> The uri on the API we are posting to
        /// <returns></returns>
        private HttpRequestMessage BuildHttpRequestMessageWithContent<T>(T requestEntity, HttpMethod httpMethod, string uri)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, uri);

            if (requestEntity != null)
            {
                var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

                var json = JsonConvert.SerializeObject(requestEntity, settings);
                requestMessage.Content = new StringContent(json);
                requestMessage.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            }

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return requestMessage;
        }
        /// <summary>
        /// Builds a singleton HttpClient and ensures ssl encryption by enforcing https. 
        /// </summary>
        /// <returns></returns>
        protected virtual HttpClient BuildSecureHttpClient()
        {
            var client = HttpClientInstance.GetInstance();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Configuration.ServerEndpoint.Contains("https") ? Configuration.ServerEndpoint : Configuration.ServerEndpoint.Replace("http", "https"));
            return client;
        }
    }
}