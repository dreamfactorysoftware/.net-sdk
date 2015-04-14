namespace DreamFactory.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Model.User;
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

            // Get Session
            session = await userApi.GetSessionAsync();
            Console.WriteLine("Session ID={0}", session.session_id);

            // Get Profile data
            var profile = await userApi.GetProfileAsync();
            Console.WriteLine("Email from your profile={0}", profile.email);

            // Changing password
            bool ok = await userApi.ChangePasswordAsync("userdream", "userdream1");
            if (ok)
            {
                // Changing password back
                if (await userApi.ChangePasswordAsync("userdream1", "userdream"))
                {
                    Console.WriteLine("Password was changed and reverted");
                }
            }

            // Logout
            bool logout = await userApi.LogoutAsync();
            Console.WriteLine("Logout {0}", logout ? "OK." : "failed.");
        }
    }
}
