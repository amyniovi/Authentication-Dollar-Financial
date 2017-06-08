using System;

namespace Dollar.Authentication.Services.Hashing
{
    public abstract class HasherBase : IHasher
    {
        public string GetHash(string value, string salt)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrEmpty(salt))
            {
                throw new ArgumentException("Value to be hashed cannot be null or empty");
            }

            return CalculateHash(value, salt);
        }

        protected abstract string CalculateHash(string value, string salt);
    }
}