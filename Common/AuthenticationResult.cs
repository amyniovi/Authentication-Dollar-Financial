using System.Collections.Generic;

namespace Dollar.Authentication.Common
{
    public class AuthenticationResult
    {
        public bool IsUserIdentifierFound { get; set; }
        public bool IsUserUnlocked { get; set; }
        public bool IsPasswordCorrect{ get; set; }
        public IEnumerable<string> FailedSecurityChecks { get; set; }
    }
}
