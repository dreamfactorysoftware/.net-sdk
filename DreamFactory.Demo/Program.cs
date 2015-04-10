namespace DreamFactory.Demo
{
    using System;

    class Program
    {
        private const string BaseAddress = "https://dsp-pinebit.cloud.dreamfactory.com";

        static void Main()
        {
            Console.WriteLine("DreamFactory REST API Demo");
            Console.WriteLine("Demo DSP address: {0}", BaseAddress);

            // HTTP functions demo
            Console.WriteLine();
            Console.WriteLine("### HTTP functions demo");
            HttpDemo.Run().Wait();

            // getServices and getResources
            Console.WriteLine();
            Console.WriteLine("### getServices and getResources demo");
            DiscoveryDemo.Run(BaseAddress).Wait();

            // UserSession API
            Console.WriteLine();
            Console.WriteLine("### UserSession API demo");
            UserSessionDemo.Run(BaseAddress).Wait();

            // Files API
            Console.WriteLine();
            Console.WriteLine("### Files API demo");
            FilesDemo.Run(BaseAddress).Wait();

            // Database API
            Console.WriteLine();
            Console.WriteLine("### Database API demo");
            DatabaseDemo.Run(BaseAddress).Wait();
        }
    }
}
