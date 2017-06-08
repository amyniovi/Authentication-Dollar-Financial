using System;

namespace Dollar.Authentication.Services.Hashing.Sh1
{
    public class Sh1Hasher : Sh1Base
    {
        protected override string CalculateHash(string value, string salt)
        {
            string saltAndValue = String.Concat(value, salt);
            return GetSh1Hash(saltAndValue);
        }
    }
}