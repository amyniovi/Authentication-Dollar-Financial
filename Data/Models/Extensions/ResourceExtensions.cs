using Dollar.Authentication.Domain;
using System;
using System.Linq;

namespace Dollar.Authentication.Data.Models.Extensions
{
    public static class ResourceExtensions
    {
        public static ResourceModel ToModel(this Resource resource)
        {
            return new ResourceModel
            {
                Id = resource.Id.ToString(),
                Name = resource.Name,
                MaximumFailedLoginAttempts = resource.MaximumFailedLoginAttempts,
                ActiveSecurityChecks =
                    resource.ActiveSecurityChecks.Select(activeSecurityCheck => activeSecurityCheck.ToModel())
            };
        }

        public static Resource ToDomain(this ResourceModel resourceModel)
        {
            if (resourceModel == null)
                return null;

            return new Resource(Guid.Parse(resourceModel.Id))
            {
                Name = resourceModel.Name,
                MaximumFailedLoginAttempts = resourceModel.MaximumFailedLoginAttempts,
                ActiveSecurityChecks =
                    resourceModel.ActiveSecurityChecks.Select(activeSecurityCheck => activeSecurityCheck.ToDomain())
            };
        }
    }
}