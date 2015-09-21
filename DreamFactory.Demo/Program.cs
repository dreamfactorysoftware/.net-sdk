namespace DreamFactory.Demo
{
    using System;
    using DreamFactory.Demo.Demo;
    using DreamFactory.Demo.Test;
    using DreamFactory.Rest;

    class Program
    {
        /*
         *  Change these settings to match your local DF installation.
         */

        internal const string BaseAddress = "http://localhost:8080";
        internal const string AppName = "<app_name>";
        internal const string AppApiKey = "<app_api_key>";
        internal const string Email = "<user_email>";
        internal const string Password = "<user_password>";

        /// <summary>
        /// This program runs both integration tests and demos.
        /// </summary>
        static void Main()
        {
            Console.Title = "DreamFactory REST API Demo";
            Console.WriteLine("Using DSP address: {0}", BaseAddress);

            // Add your tests/demo here
            IRunnable[] tests =
            {
                new LoginDemo(),
                new DiscoveryDemo(), 
                new UserDemo(),
                new EmailDemo(), 
                new DatabaseDemo(), 
                new FilesDemo(), 
                new SystemDemo(),
                new CustomSettingsDemo(),
                new SystemAppTest(),
                new SystemUserTest(),
                new SystemRoleTest(),
                new SystemEventTest(),
                new LogoutDemo(),
                new HttpDemo()
            };

            IRestContext context = new RestContext(BaseAddress, AppName, AppApiKey, RestApiVersion.V2);

            Array.ForEach(tests, test =>
            {
                Console.WriteLine();
                Console.WriteLine("***** {0} ******", test.GetType().Name);
                test.RunAsync(context).Wait();
            });

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Total tests: {0}.", tests.Length);
            Console.ReadLine();
        }
    }
}
