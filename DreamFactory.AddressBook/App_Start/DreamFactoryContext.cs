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
        public const string AppName = "<app_name>";
        public const string AppApiKey = "<app_api_key>";
        public const string BaseAddress = "http://localhost:8080";
        public const string DbServiceName = "db";
        public const string FileServiceName = "files";

        #region security

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

        #endregion

        public static IRestContext Create()
        {
            return new RestContext(BaseAddress, AppName, AppApiKey, SessionId, Version);
        }
    }
}