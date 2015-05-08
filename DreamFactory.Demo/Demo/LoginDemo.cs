namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;

    public class LoginDemo : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            IUserApi userApi = context.Factory.CreateUserApi();
            Session session = await userApi.LoginAsync(Program.DefaultApp, Program.Email, Program.Password);
            Console.WriteLine("Logged in as {0}", session.display_name);
        }
    }
}