using System.ComponentModel.Composition;

namespace Dollar.Authentication.Services.Hashing
{
    [InheritedExport]
    public interface IHasher
    {
        string GetHash(string value, string salt);
    }
}