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
        public const string AppName = "Address Book ASP.NET";
        public const string AppApiKey = "2d82361322f9b76f5550cb02285eb22393963dc8900738a5bde629c53742f8a5";
        public const string BaseAddress = "http://dfv204.cloudapp.net:8080/";
        public const string DbServiceName = "db3";
        public const string EmailServiceName = "mail";
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