using System.Security.Claims;

namespace Dollar.Authentication.Common
{
    public class AuthRequest
    {
        public ClaimsIdentity Identity { get; set; }
        public string ResourceName { get; set; }
    }
}