using System;

namespace Dollar.Authentication.Domain
{
    public class SecurityCheck
    {
        public SecurityCheck(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTime CreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            var securityCheck = obj as SecurityCheck;

            if (securityCheck == null)
            {
                return false;
            }

            return Key == securityCheck.Key &&
                   Value == securityCheck.Value;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode() ^
                   Value.GetHashCode();
        }
    }
}