namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;

    public static class UserDemo
    {
        public static async Task Run(IRestContext context)
        {
            // IUserApi provides all functions for user management
            IUserApi userApi = context.Factory.CreateUserApi();

            // getSession()
            Session session = await userApi.GetSessionAsync();
            Console.WriteLine("Session ID: {0}", session.session_id);

            // getProfile()
            ProfileResponse profile = await userApi.GetProfileAsync();
            Console.WriteLine("Email from your profile: {0}", profile.email);

            // changePassword()
            const string newPassword = Program.Password + "new";
            bool ok = await userApi.ChangePasswordAsync(Program.Password, newPassword);
            if (ok)
            {
                // Changing password back
                if (await userApi.ChangePasswordAsync(newPassword, Program.Password))
                {
                    Console.WriteLine("Password was changed and reverted");
                }
            }
        }
    }
}
