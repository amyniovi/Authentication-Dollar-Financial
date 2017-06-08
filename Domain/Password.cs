using System;

namespace Dollar.Authentication.Domain
{
    public class Password
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Version { get; set; }
        public DateTime CreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            var password = obj as Password;

            if (password == null)
            {
                return false;
            }

            return Hash == password.Hash &&
                   Salt == password.Salt &&
                   Version == password.Version;
        }

        public override int GetHashCode()
        {
            return Hash.GetHashCode() ^
                   Salt.GetHashCode() ^
                   Version.GetHashCode();
        }
    }
}