namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.System.Custom;
    using DreamFactory.Rest;

    public class CustomSettingsDemo : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            ICustomSettingsApi settingsApi = context.Factory.CreateUserCustomSettingsApi();

            // Setting some preferences
            List<CustomRequest> customSettings = new List<CustomRequest>
            {
                new CustomRequest
                {
                    Name = "Language",
                    Value = "en-us"
                },
                new CustomRequest
                {
                    Name = "TimeZone",
                    Value = "ET"
                }
            };

            if ((await settingsApi.SetCustomSettingsAsync(customSettings)).Records.Any())
            {
                Console.WriteLine("Created custom settings: preferences");
            }

            // Retrieving custom settings names
            IEnumerable<string> names = (await settingsApi.GetCustomSettingsAsync()).Records.Select(x => x.Name);
            string flatList = string.Join(", ", names);
            Console.WriteLine("Retrieved available setting names: [{0}]", flatList);

            // Retrieving preferences back
            CustomResponse custom = await settingsApi.GetCustomSettingAsync("Language");
            Console.WriteLine("Retrieved preferences back:");
            Console.WriteLine("\tName={0}, Value={1}", "Language", custom.Value);

            // Deleting preferences
            await settingsApi.DeleteCustomSettingAsync("Language");
            Console.WriteLine("Deleted Language preferences!");
            await settingsApi.DeleteCustomSettingAsync("TimeZone");
            Console.WriteLine("Deleted TimeZone preferences!");
        }
    }
}
