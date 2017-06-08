using System;
using System.Collections.Generic;

namespace Dollar.Authentication.Services.Hashing
{
    public static class HashComparerFactory
    {
        public static HashComparer Create()
        {
            var hasherImporter = new HasherImporter();
            IEnumerable<Lazy<IHasher>> hashers = hasherImporter.GetImports();
            return new HashComparer(hashers);
        }
    }
}