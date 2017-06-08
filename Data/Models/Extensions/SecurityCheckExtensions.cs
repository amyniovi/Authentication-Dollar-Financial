using Dollar.Authentication.Domain;

namespace Dollar.Authentication.Data.Models.Extensions
{
    public static class SecurityCheckExtensions
    {
        public static SecurityCheckModel ToModel(this SecurityCheck securityCheck)
        {
            return new SecurityCheckModel
            {
                Key = securityCheck.Key,
                Value = securityCheck.Value,
                CreatedOn = securityCheck.CreatedOn
            };
        }

        public static SecurityCheck ToDomain(this SecurityCheckModel securityCheckModel)
        {
            if (securityCheckModel == null)
                return null;

            return new SecurityCheck(securityCheckModel.Key, securityCheckModel.Value)
            {
                CreatedOn = securityCheckModel.CreatedOn
            };
        }
    }
}