using Dollar.Authentication.Domain;
using System;
using System.Linq;

namespace Dollar.Authentication.Data.Models.Extensions
{
    public static class IdentityExtensions
    {
        public static IdentityModel ToModel(this Identity identity)
        {
            return new IdentityModel
            {
                Id = identity.Id.ToString(),
                ResourceName = identity.ResourceName,
                UserId = identity.UserId,
                AccountLocked = identity.AccountLocked,
                CreatedOn = identity.CreatedOn,
                LastSuccessfulLogin = identity.LastSuccessfulLogin,
                FailedLoginAttempts = identity.FailedLoginAttempts,
                Passwords = identity.Passwords.Select(password => password.ToModel()),
                SecurityChecks = identity.SecurityChecks.Select(securityCheck => securityCheck.ToModel())
            };
        }

        public static Identity ToDomain(this IdentityModel identityModel)
        {
            if (identityModel == null)
                return null;

            return new Identity(Guid.Parse(identityModel.Id))
            {
                ResourceName = identityModel.ResourceName,
                UserId = identityModel.UserId,
                AccountLocked = identityModel.AccountLocked,
                CreatedOn = identityModel.CreatedOn,
                LastSuccessfulLogin = identityModel.LastSuccessfulLogin,
                FailedLoginAttempts = identityModel.FailedLoginAttempts,
                Passwords = identityModel.Passwords.Select(password => password.ToDomain()),
                SecurityChecks =
                    identityModel.SecurityChecks.Select(securityCheck => securityCheck.ToDomain())
            };
        }
    }
}