using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Dollar.Authentication.Common;

namespace HostServer
{
    public class AuthorizationController : ApiController
    {
        // POST /api/authorize
        [Route("~/api/authorize")]
        public ValidationResponse Authorize([FromBody] AuthRequest request)
        {
            return new ValidationResponse { IsPasswordCorrect = true, IsUserIdentifierFound = true, IsUserUnlocked = true };
        }
    }
}
