namespace DreamFactory.Demo.IntegrationTest
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;

    /*
     * The test is designed to run with local DreamFactory installation.
     * Change the constants below to match your setup.
     */

    public static class Test
    {
        private const string BaseAddress = "http://localhost";
        private const string DefaultApp = "todoangular";
        private const string Email = "admin@mail.com";
        private const string Password = "dream";

        private static readonly ConsoleColor[] Colors =
        {
            ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Yellow
        };

        static void Main()
        {
            Console.WriteLine("Integration test");

            RunTest().Wait();

            Console.ResetColor();
        }

        static async Task RunTest()
        {
            IRestContext context = new RestContext(BaseAddress);

            SwitchColor();
            await Login(context);

            SwitchColor();
            await SystemUserTest.RunTest(context);

            SwitchColor();
            await SystemRoleTest.RunTest(context);

            SwitchColor();
            await DevicesTest.RunTest(context);

            SwitchColor();
            await SystemScriptTest.RunTest(context);

            SwitchColor();
            await Logout(context);
        }

        static async Task Login(IRestContext context)
        {
            IUserApi userApi = context.Factory.CreateUserApi();
            Session session = await userApi.LoginAsync(DefaultApp, Email, Password);
            Console.WriteLine("Logged in as {0}", session.display_name);
        }

        static async Task Logout(IRestContext context)
        {
            IUserApi userApi = context.Factory.CreateUserApi();
            bool success = await userApi.LogoutAsync();
            Console.WriteLine("Logged out, success={0}", success);
        }

        static void SwitchColor()
        {
            int index = Array.IndexOf(Colors, Console.ForegroundColor) + 1;
            if (index >= Colors.Length)
            {
                index = 0;
            }

            Console.ForegroundColor = Colors[index];
            Console.WriteLine();
        }
    }
}
