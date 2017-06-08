using Dollar.Authentication.Common;

namespace Dollar.Authentication.Client
{
    public interface IApiClient
    {
        IConfiguration Configuration { get; set; }
        ValidationResponse RequestAuthorization(AuthRequest authRequest);
    }
}