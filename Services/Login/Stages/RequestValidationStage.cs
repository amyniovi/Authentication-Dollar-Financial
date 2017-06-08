using Dollar.Authentication.Data;
using System.Linq;

namespace Dollar.Authentication.Services.Login.Stages
{
    public class RequestValidationStage : ILoginStage
    {
        private readonly IResourceRepository _resourceRepository;

        public RequestValidationStage(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public bool Validate(LoginContext context)
        {
            var resourceConfig = _resourceRepository.GetByName(context.Request.ResourceName);
            return resourceConfig.ActiveSecurityChecks.All(
                activeSecurityCheck =>
                    context.Request.Identity.Claims.Any(
                        unvalidatedClaim => unvalidatedClaim.Type == activeSecurityCheck.Key));
        }
    }
}
