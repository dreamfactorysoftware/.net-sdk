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
            ISystemApi systemApi = context.Factory.CreateSystemApi();
            bool success = await systemApi.LogoutAdminAsync();
            Console.WriteLine("Logged out, success={0}", success);

            //IUserApi userApi = context.Factory.CreateUserApi();
            //bool success = await userApi.LogoutAsync();
            //Console.WriteLine("Logged out, success={0}", success);
        }
    }
}