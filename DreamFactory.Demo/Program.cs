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

        internal const string BaseAddress = "http://localhost:8765";
        internal const string AppName = "demo";
        internal const string AppApiKey = "eea04e3e9b2b2a452cb1b49bbae52fa9a4336b874a5267608586378246ee4ebb";
        internal const string Email = "dream@factory.com";
        internal const string Password = "dreamfactory";

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
                //new DiscoveryDemo(), 
                //new UserDemo(),
                //new EmailDemo(), 
                //new DatabaseDemo(), 
                //new FilesDemo(), 
                //new SystemDemo(),
                //new CustomSettingsDemo(),
                new SystemAppTest(),
                //new SystemUserTest(),
                //new SystemRoleTest(),
                //new SystemScriptTest(),
                //new SystemEventTest(),
                //new LogoutDemo(),
                //new HttpDemo()
            };

            IRestContext context = new RestContext(BaseAddress, RestApiVersion.V2);

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
