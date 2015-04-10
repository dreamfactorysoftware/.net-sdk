namespace DreamFactory.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Rest;

    public static class UserSessionDemo
    {
        public static async Task Run(string baseAddress)
        {
            // Login
            IRestContext context = new RestContext(baseAddress);
            IUserSessionApi userSessionApi = context.Factory.CreateUserSessionApi();
            Session session = await userSessionApi.LoginAsync("admin", Utils.CreateLogin());
            Console.WriteLine("Logged in as {0}", session.display_name);
            Console.WriteLine("Session ID={0}", session.session_id);

            // Logout
            Logout logout = await userSessionApi.LogoutAsync();
            Console.WriteLine("Logout {0}", logout.success ? "OK." : "failed.");
        }
    }
}
