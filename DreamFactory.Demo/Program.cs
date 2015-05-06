namespace DreamFactory.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Demo.Demo;
    using DreamFactory.Demo.IntegrationTest;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;

    class Program
    {
        /*
         *  Change these settings to match your local DF installation.
         */

        internal const string BaseAddress = "http://localhost";
        internal const string DefaultApp = "todoangular";
        internal const string Email = "admin@mail.com";
        internal const string Password = "dream";

        delegate Task TestRunner(IRestContext context);

        /// <summary>
        /// This program runs both integration tests and demos.
        /// </summary>
        static void Main()
        {
            Console.Title = "DreamFactory REST API Demo";
            Console.WriteLine("Using DSP address: {0}", BaseAddress);

            // Add your tests/demo here
            TestRunner[] tests =
            {
                Login,
                SystemUserTest.Run,
                SystemRoleTest.Run,
                SystemDeviceTest.Run,
                SystemScriptTest.Run,
                SystemEventTest.Run,
                UserDemo.Run,
                CustomSettingsDemo.Run,
                DatabaseDemo.Run,
                DiscoveryDemo.Run,
                EmailDemo.Run,
                FilesDemo.Run,
                SystemDemo.Run,
                HttpDemo.Run,
                Logout
            };

            IRestContext context = new RestContext(BaseAddress);

            Array.ForEach(tests, test =>
            {
                Console.WriteLine();
                test(context).Wait();
            });

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Total tests: {0}.", tests.Length);
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
    }
}
