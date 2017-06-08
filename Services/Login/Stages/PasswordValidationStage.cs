
using Dollar.Authentication.Common;
using Dollar.Authentication.Services.Hashing;
using System.Linq;

namespace Dollar.Authentication.Services.Login.Stages
{
    public class PasswordValidationStage : ILoginStage
    {
        public bool Validate(LoginContext context)
        {
            var sentPassword = context.Request.Identity.FindFirst(AuthUri.PasswordUri(context.Request.ResourceName).ToString()).Value;
            var storedPassword = context.StoredIdentity.Passwords.OrderByDescending(p => p.CreatedOn).FirstOrDefault();

            var hashComparer = HashComparerFactory.Create();
            return hashComparer.Compare(sentPassword, storedPassword);
        }
    }
}
