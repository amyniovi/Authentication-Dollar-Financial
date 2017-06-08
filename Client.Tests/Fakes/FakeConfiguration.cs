using Dollar.Authentication.Client;

namespace Client.Tests.Fakes
{
    public class FakeConfiguration : IConfiguration
    {
        private readonly bool _nullConfigValues;

        public FakeConfiguration(bool nullConfigValues = false)
        {
            _nullConfigValues = nullConfigValues;
        }
        public string ResourceName
        {
            get { return _nullConfigValues ? null : TestConstants.ResourceName; }
        }
        public string AuthTimeout
        {
            get { return _nullConfigValues ? null : TestConstants.TimeOutInSecs; }
        }
        public string ServerEndpoint
        {
            get { return _nullConfigValues ? null : TestConstants.ServerEndpoint; }
        }      
    }
}
