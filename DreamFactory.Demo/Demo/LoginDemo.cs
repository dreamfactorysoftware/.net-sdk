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
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            try
            {
                Session session = await systemApi.LoginAdminAsync(Program.Email, Program.Password);
                Console.WriteLine("Logged in as {0}", session.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unfortunately, something went wrong.");
                Console.WriteLine("Please check the following:");
                Console.WriteLine("\t- your DSP is listening: {0}", Program.BaseAddress);
                Console.WriteLine("\t- you have created user '{0}' with password '{1}'", Program.Email, Program.Password);
                Console.WriteLine();
                Console.ResetColor();

                throw;
            }
        }
    }
}