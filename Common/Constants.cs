namespace Dollar.Authentication.Common
{
    public class Constants
    {
        public const string CLAIM_NAMESPACE = "http://myclaims/";
        public const string AUTHENTICATION_TYPE = "AuthenticationPOC";
        public const string GENERIC_APICOMMUNICATION_ERROR = "There was a problem communicating with the API Host";
        public const string GENERIC_NOCLAIMS_ERROR = "No Claims provided";
        public const string GENERIC_NORESOURCE_ERROR = "There was no Resource Name provided";
        public const string GENERIC_NOPASSWORDORUSERNAME_ERROR = "Username or Password is not provided";
        public const string GENERIC_TIMEOUT_ERROR = "The operation is taking too long, the request has timed out.";
        public const string CONFIG_SECTION = "dollarAuthClient";
        public const string CONFIG_RESOURCEID = "ResourceId";
        public const string CONFIG_SERVERENDPOINT = "ServerEndpoint";
        public const string CONFIG_TIMEOUT_INSECS = "AuthTimeout";
    }
}
