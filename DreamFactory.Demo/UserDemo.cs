namespace DreamFactory.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Rest;

    public static class UserDemo
    {
        public static async Task Run(string baseAddress)
        {
            // Login
            IRestContext context = new RestContext(baseAddress);
            IUserApi userSessionApi = context.Factory.CreateUserApi();
            Session session = await userSessionApi.LoginAsync("admin", Utils.CreateLogin());
            Console.WriteLine("Logged in as {0}", session.display_name);

            // GetSession
            session = await userSessionApi.GetSessionAsync();
            Console.WriteLine("Session ID={0}", session.session_id);

            // Logout
            bool logout = await userSessionApi.LogoutAsync();
            Console.WriteLine("Logout {0}", logout ? "OK." : "failed.");
        }
    }
}
