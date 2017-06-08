using System;
using System.Collections.Generic;

namespace Dollar.Authentication.Domain
{
    public class Resource
    {
        private IEnumerable<ActiveSecurityCheck> _activeSecurityChecks = new List<ActiveSecurityCheck>();

        public Resource()
        {
            Id = Guid.NewGuid();
        }

        public Resource(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int MaximumFailedLoginAttempts { get; set; }

        public IEnumerable<ActiveSecurityCheck> ActiveSecurityChecks
        {
            get { return _activeSecurityChecks; }
            set { _activeSecurityChecks = value; }
        }
    }
}