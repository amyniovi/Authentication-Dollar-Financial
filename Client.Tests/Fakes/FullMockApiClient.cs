
using Dollar.Authentication.Client;
using Dollar.Authentication.Common;

namespace Client.Tests.Fakes
{
    public class FullMockApiClient : IApiClient
    {
        public FullMockApiClient(bool nullConfigurationValues = false)
        {
            Configuration = new FakeConfiguration(nullConfigurationValues);
        }

        public bool IsRequestAuthorizationCalled { get; private set; }
        public AuthRequest AuthorizationRequestCreated { get; private set; }
        public bool ReturnSuccesfulAuthentication { private get; set; }
        public IConfiguration Configuration { get; set; }
        public ValidationResponse RequestAuthorization(AuthRequest authRequest)
        {
            AuthorizationRequestCreated = authRequest;

            IsRequestAuthorizationCalled = true;
            return ReturnSuccesfulAuthentication
                ? new ValidationResponse { IsPasswordCorrect = true, IsUserIdentifierFound = true, IsUserUnlocked = true }
                : new ValidationResponse();
        }
    }
}
