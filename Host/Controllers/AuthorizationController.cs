using Dollar.Authentication.Common;
using System;
using System.Web.Http;

namespace Dollar.Authentication.Host.Controllers
{
    public class AuthorizationController : ApiController
    {
        // POST /api/authorize
        [Route("~/api/authorize")]
        public ValidationResponse Authorize([FromBody] AuthRequest request)
        {
            throw new NotImplementedException();
        }
    }
}