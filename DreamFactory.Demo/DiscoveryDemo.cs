namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model;
    using DreamFactory.Rest;

    public static class DiscoveryDemo
    {
        public static async Task Run(IRestContext context)
        {
            // List available services
            IEnumerable<Service> services = context.GetServicesAsync().Result;
            Console.WriteLine();
            Console.WriteLine("Available services:");
            foreach (Service service in services)
            {
                Console.WriteLine("{0}:\t{1}", service.api_name, service.name);
            }

            // List resources
            IEnumerable<Resource> resources = await context.GetResourcesAsync("user");
            Console.WriteLine();
            Console.WriteLine("/user resources:");
            foreach (Resource resource in resources)
            {
                Console.WriteLine("\t/{0}", resource.name);
            }

            resources = await context.GetResourcesAsync("files");
            Console.WriteLine();
            Console.WriteLine("/files resources:");
            foreach (Resource resource in resources)
            {
                Console.WriteLine("\t/{0}", resource.name);
            }
        }
    }
}
