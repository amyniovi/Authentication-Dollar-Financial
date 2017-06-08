using Dollar.Authentication.Domain;

namespace Dollar.Authentication.Data.Models.Extensions
{
    public static class ActiveSecurityCheckExtensions
    {
        public static ActiveSecurityCheckModel ToModel(this ActiveSecurityCheck activeSecurityCheck)
        {
            return new ActiveSecurityCheckModel
            {
                Key = activeSecurityCheck.Key,
                CreatedOn = activeSecurityCheck.CreatedOn,
            };
        }

        public static ActiveSecurityCheck ToDomain(this ActiveSecurityCheckModel activeSecurityCheckModel)
        {
            if (activeSecurityCheckModel == null)
                return null;

            return new ActiveSecurityCheck
            {
                Key = activeSecurityCheckModel.Key,
                CreatedOn = activeSecurityCheckModel.CreatedOn
            };
        }
    }
}