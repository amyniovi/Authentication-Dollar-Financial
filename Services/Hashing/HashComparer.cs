using Dollar.Authentication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dollar.Authentication.Services.Hashing
{
    public class HashComparer
    {
        private readonly IEnumerable<Lazy<IHasher>> _hashers;

        public HashComparer(IEnumerable<Lazy<IHasher>> hashers)
        {
            _hashers = hashers;
        }

        public bool Compare(string clearString, Password password)
        {
            Lazy<IHasher> hasher =
                _hashers.SingleOrDefault(h => h.Value.GetType().AssemblyQualifiedName == password.Version);

            if (hasher == null)
            {
                throw new InvalidOperationException(string.Format("IHasher could not be retrieved for type '{0}'",
                    password.Version));
            }

            string hash = hasher.Value.GetHash(clearString, password.Salt);
            return hash == password.Hash;
        }
    }
}