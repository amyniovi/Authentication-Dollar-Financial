
using Dollar.Authentication.Data;

namespace Dollar.Authentication.Services.Login.Stages
{
    public class IdentityRetrievalStage : ILoginStage
    {
        private readonly IIdentityRepository _repository;

        public IdentityRetrievalStage(IIdentityRepository repository)
        {
            _repository = repository;
        }

        public bool Validate(LoginContext context)
        {
            var identity = _repository.GetByResourceAndUserId(context.Request.ResourceName, context.Request.Identity.Name);
            context.StoredIdentity = identity;
            return identity == null;
        }
    }
}
