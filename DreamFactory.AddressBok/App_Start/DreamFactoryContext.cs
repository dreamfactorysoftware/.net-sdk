namespace DreamFactory.AddressBook
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using global::DreamFactory.Rest;

    public static class DreamFactoryContext
    {
        public const RestApiVersion Version = RestApiVersion.V2;
        public const string AppName = "Address Book ASP.NET";
        public const string AppApiKey = "b8cb104c4435861c6ba476cf73c14e7a51c66e026094be7827c3d11525f0f6a4";
        public const string BaseAddress = "http://dfv20.cloudapp.net/";
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

        public static IRestContext Create()
        {
            return new RestContext(BaseAddress, AppName, AppApiKey, SessionId, Version);
        }
    }
}