namespace DreamFactory.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;

    class Program
    {
        private const string BaseAddress = "https://dsp-pinebit.cloud.dreamfactory.com";
        private const string DefaultApp = "todoangular";

        static void Main()
        {
            Console.WriteLine("DreamFactory REST API Demo");
            Console.WriteLine("Using DSP address: {0}", BaseAddress);

            // RestContext is the root object providing access to all APIs
            IRestContext context = new RestContext(BaseAddress);

            // API calls require a session, hence we must login
            Login(context).Wait();

            // UserSession API
            Console.WriteLine();
            Console.WriteLine("### User API demo");
            UserDemo.Run(context).Wait();

            // UserSession API
            Console.WriteLine();
            Console.WriteLine("### Custom Settings demo");
            CustomSettingsDemo.Run(context).Wait();

            // getServices and getResources
            Console.WriteLine();
            Console.WriteLine("### getServices and getResources demo");
            DiscoveryDemo.Run(context).Wait();

            // Files API
            Console.WriteLine();
            Console.WriteLine("### Files API demo");
            FilesDemo.Run(context).Wait();

            // Database API
            Console.WriteLine();
            Console.WriteLine("### Database API demo");
            DatabaseDemo.Run(context).Wait();

            // Email API
            Console.WriteLine();
            Console.WriteLine("### Email API demo");
            EmailDemo.Run(context).Wait();

            // System API
            Console.WriteLine();
            Console.WriteLine("### System API demo");
            SystemDemo.Run(context).Wait();

            // HTTP functions demo (do not require IRestContext)
            Console.WriteLine();
            Console.WriteLine("### HTTP functions demo");
            HttpDemo.Run().Wait();
        }

        static async Task Login(IRestContext context)
        {
            IUserApi userApi = context.Factory.CreateUserApi();
            Session session = await userApi.LoginAsync(DefaultApp, "user@mail.com", "userdream");
            Console.WriteLine("Logged in as {0}", session.display_name);
        }
    }
}
