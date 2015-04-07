namespace DreamFactory.Demo
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("DreamFactory REST API Demo");
            Console.WriteLine();

            // HTTP functions demo
            Console.WriteLine("### HTTP functions demo");
            HttpDemo.Run().Wait();
        }
    }
}
