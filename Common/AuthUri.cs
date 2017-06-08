using System;

namespace Dollar.Authentication.Common
{
    public class AuthUri : Uri
    {
        private static readonly Uri BaseUri = new Uri("auth://dollar/");

        public AuthUri(string resourceName, string propertyName) : base (BaseUri, string.Format("{0}/{1}", resourceName, propertyName))
        { }

        public static AuthUri PasswordUri(string resourceName)
        {
            return new AuthUri(resourceName, "password");
        }

        public static AuthUri UserIdentifierUri(string resourceName)
        {
            return new AuthUri(resourceName, "userIdentifier");
        }
    }
}
