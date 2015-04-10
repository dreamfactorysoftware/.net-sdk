namespace DreamFactory.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Rest;

    public static class DiscoveryDemo
    {
        public static async Task Run(string baseAddress)
        {
            // Login first
            IRestContext context = new RestContext(baseAddress);
            IUserSessionApi userSessionApi = context.Factory.CreateUserSessionApi();
            Session session = await userSessionApi.LoginAsync("todoangular", Utils.CreateLogin());
            Console.WriteLine("Logged in as {0}", session.display_name);

            // List available services
            Services services = context.GetServicesAsync().Result;
            Console.WriteLine();
            Console.WriteLine("Available services:");
            foreach (Service service in services.service)
            {
                Console.WriteLine("{0}:\t{1}", service.api_name, service.name);
            }

            // List resources
            Resources resources = await context.GetResourcesAsync("user");
            Console.WriteLine();
            Console.WriteLine("/user resources:");
            foreach (Resource resource in resources.resource)
            {
                Console.WriteLine("\t/{0}", resource.name);
            }

            resources = await context.GetResourcesAsync("files");
            Console.WriteLine();
            Console.WriteLine("/files resources:");
            foreach (Resource resource in resources.resource)
            {
                Console.WriteLine("\t/{0}", resource.name);
            }
        }
    }
}
