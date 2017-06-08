namespace Dollar.Authentication.Client.Globals
{
    public class GlobalResources
    {
        public static string RoutePrefix
        {
            get { return  "/api" + GlobalVersion; }
        }

        public static string GlobalVersion
        {
            //get {return "/v1";}
            get { return ""; }
        }

        public static string LoginUrl
        {
            get { return RoutePrefix + "/authorize"; }
        }
    }
}
