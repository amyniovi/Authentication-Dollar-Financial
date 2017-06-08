using System;
using System.Collections.Generic;

namespace Dollar.Authentication.Domain
{
    public class Identity
    {
        private IEnumerable<DateTime> _failedLoginAttempts = new List<DateTime>();
        private IEnumerable<Password> _passwords = new List<Password>();
        private IEnumerable<SecurityCheck> _securityChecks = new List<SecurityCheck>();

        public Identity(Guid id)
        {
            Id = id;
        }

        public Identity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string UserId { get; set; }
        public string ResourceName { get; set; }

        public DateTime? LastSuccessfulLogin { get; set; }
        public bool AccountLocked { get; set; }
        public DateTime CreatedOn { get; set; }

        public IEnumerable<DateTime> FailedLoginAttempts
        {
            get { return _failedLoginAttempts; }
            set { _failedLoginAttempts = value; }
        }

        public IEnumerable<Password> Passwords
        {
            get { return _passwords; }
            set { _passwords = value; }
        }

        public IEnumerable<SecurityCheck> SecurityChecks
        {
            get { return _securityChecks; }
            set { _securityChecks = value; }
        }
    }
}