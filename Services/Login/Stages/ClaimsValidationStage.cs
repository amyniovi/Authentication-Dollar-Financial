using System;
using System.Linq;

namespace Dollar.Authentication.Services.Login.Stages
{
    public class ClaimsValidationStage : ILoginStage
    {
        public bool Validate(LoginContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "LoginContext is null");
            }

            if (context.StoredIdentity == null)
            {
                throw new ArgumentException("LoginContext contains a null StoredIdentity");
            }

            if (context.Request == null)
            {
                throw new ArgumentException("LoginContext contains a null Request");
            }

            return
                context.StoredIdentity.SecurityChecks.All(
                    storedClaim =>
                        context.Request.Identity.Claims.Any(
                            unvalidatedClaim =>
                                unvalidatedClaim.Type == storedClaim.Key && unvalidatedClaim.Value == storedClaim.Value));
        }
    }
}
