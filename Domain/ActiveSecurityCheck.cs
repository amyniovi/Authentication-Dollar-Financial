using System;

namespace Dollar.Authentication.Domain
{
    public class ActiveSecurityCheck
    {
        public string Key { get; set; }
        public DateTime CreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            var securityCheck = obj as ActiveSecurityCheck;

            if (securityCheck == null)
            {
                return false;
            }

            return Key == securityCheck.Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}