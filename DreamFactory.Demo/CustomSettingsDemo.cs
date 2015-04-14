namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Rest;

    public static class CustomSettingsDemo
    {
        public static async Task Run(IRestContext context)
        {
            IUserApi userApi = context.Factory.CreateUserApi();

            // Setting custom settings
            Dictionary<string, Dictionary<string, object>> settings =
                new Dictionary<string, Dictionary<string, object>>
                {
                    { "setting1", new Dictionary<string, object> { { "age", 33 }, { "name", "John" } } },
                    { "setting2", new Dictionary<string, object> { { "enabled", true } } },
                };

            if (!await userApi.SetCustomSettingsAsync(settings))
            {
                Console.WriteLine("Failed to create custom settings!");
            }
            else
            {
                Console.WriteLine("Created custom settings: setting1, setting2");
            }

            // Retrieving custom settings
            Console.WriteLine("Retrieved custom settings:");
            settings = await userApi.GetCustomSettingsAsync();

            foreach (KeyValuePair<string, Dictionary<string, object>> setting in settings)
            {
                if (!setting.Key.StartsWith("setting"))
                {
                    continue;
                }

                Console.WriteLine("\tcustom setting '{0}'", setting.Key);
                Console.WriteLine("\t{");

                foreach (KeyValuePair<string, object> pair in setting.Value)
                {
                    Console.WriteLine("\t\tname: '{0}', values: {1}", pair.Key, pair.Value);
                }

                Console.WriteLine("\t}");

                // Delete the custom setting
                if (await userApi.DeleteCustomSettingAsync(setting.Key))
                {
                    Console.WriteLine("\t... and '{0}' is now deleted", setting.Key);
                }
            }
        }
    }
}
