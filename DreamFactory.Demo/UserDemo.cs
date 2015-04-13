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
            IUserApi userApi = context.Factory.CreateUserApi();
            Session session = await userApi.LoginAsync("admin", Utils.CreateLogin());
            Console.WriteLine("Logged in as {0}", session.display_name);

            // GetSession
            session = await userApi.GetSessionAsync();
            Console.WriteLine("Session ID={0}", session.session_id);

            var profile = await userApi.GetProfileAsync();
            Console.WriteLine("Email from your profile={0}", profile.email);

            // Logout
            bool logout = await userApi.LogoutAsync();
            Console.WriteLine("Logout {0}", logout ? "OK." : "failed.");
        }
    }
}
