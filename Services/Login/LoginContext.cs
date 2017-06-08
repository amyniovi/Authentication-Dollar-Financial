using Dollar.Authentication.Common;
using Dollar.Authentication.Domain;

namespace Dollar.Authentication.Services.Login
{
    public class LoginContext
    {
        public Identity StoredIdentity { get; set; }

        public AuthRequest Request { get; set; }
    }
}