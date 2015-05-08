namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Rest;

    public class LogoutDemo : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            IUserApi userApi = context.Factory.CreateUserApi();
            bool success = await userApi.LogoutAsync();
            Console.WriteLine("Logged out, success={0}", success);
        }
    }
}