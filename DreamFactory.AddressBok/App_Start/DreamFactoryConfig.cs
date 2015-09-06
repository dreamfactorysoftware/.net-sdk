namespace DreamFactory.AddressBook
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using global::DreamFactory.Rest;

    public static class DreamFactoryConfig
    {
        public const RestApiVersion Version = RestApiVersion.V2;
        public const string AppName = "admin";
        public const string AppApiKey = "6498a8ad1beb9d84d63035c5d1120c007fad6de706734db9689f8996707e0f7d";
        public const string BaseAddress = "http://dfv2.cloudapp.net:8080";
        public const string DbServiceName = "mysql";
        public const string EmailServiceName = "email";
        public const string FileServiceName = "files";
        public const string SessionIdClaimType = "http://dreamfactory.com/claims/sessionid";

        public static string SessionId
        {
            get
            {
                if (HttpContext.Current.User == null || HttpContext.Current.User.Identity == null)
                {
                    return string.Empty;
                }

                ClaimsIdentity identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                IEnumerable<Claim> claims = identity.Claims;
                return claims.Where(x => x.Type == SessionIdClaimType).Select(x => x.Value).FirstOrDefault();
            }
        }

        public struct Roles
        {
            public const string SysAdmin = "sys_admin";
        }
    }
}