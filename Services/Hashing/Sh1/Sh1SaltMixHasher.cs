using System.Collections.Generic;

namespace Dollar.Authentication.Services.Hashing.Sh1
{
    public class Sh1SaltMixHasher : Sh1Base
    {
        protected override string CalculateHash(string value, string salt)
        {
            var saltAndValueList = new List<char>();
            var saltQueue = new Queue<char>(salt.ToCharArray());

            foreach (char character in value)
            {
                saltAndValueList.Add(character);
                saltAndValueList.Add(saltQueue.Dequeue());

                if (saltQueue.Count == 0)
                {
                    saltQueue = new Queue<char>(salt.ToCharArray());
                }
            }

            var saltAndValue = new string(saltAndValueList.ToArray());
            return GetSh1Hash(saltAndValue);
        }
    }
}