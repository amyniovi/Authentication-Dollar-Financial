using System.Collections.Generic;
using System.Linq;

namespace Dollar.Authentication.Common
{
    public class ValidationResponse
    {
        public bool IsUserIdentifierFound { get; set; }
        public bool IsUserUnlocked { get; set; }
        public bool IsPasswordCorrect { get; set; }
        public IEnumerable<string> FailedSecurityChecks { get; set; }

        public bool IsAuthorized()
        {
            return IsPasswordCorrect &&
                   IsUserIdentifierFound &&
                   IsUserUnlocked &&    
                   (FailedSecurityChecks == null || FailedSecurityChecks.Any() == false);
        }
    }
}