namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;

    public class UserDemo : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            // IUserApi provides all functions for user management
            IUserApi userApi = context.Factory.CreateUserApi();

            // getSession()
            Session session = await userApi.GetSessionAsync();
            Console.WriteLine("Session ID: {0}", session.SessionId);

            // getProfile()
            ProfileResponse profile = await userApi.GetProfileAsync();
            Console.WriteLine("Email from your profile: {0}", profile.Email);

            // register()
            string guid = Guid.NewGuid().ToString();
            Register register = new Register
            {
                FirstName = guid.Substring(0, 6),
                LastName = guid.Substring(0, 6),
                Email = guid.Substring(0, 6) + "@factory.com",
                DisplayName = guid.Substring(0, 6),
                NewPassword = guid.Substring(0, 6)
            };
            bool ok = await userApi.RegisterAsync(register, true);

            if (ok)
            {
                Console.WriteLine("Successfully registered user: {0}", guid.Substring(0,8));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unfortunately, something went wrong.");
            }
        }
    }
}
