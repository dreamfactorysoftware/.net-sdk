namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Rest;

    public class CustomSettingsDemo : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            ICustomSettingsApi settingsApi = context.Factory.CreateUserCustomSettingsApi();

            // Setting some preferences
            UserPreferences preferences = new UserPreferences
            {
                Flag = true,
                Array = new[] { "a", "b", "c" },
                Entity = new Entity { Rank = 4, Role = "user" }
            };

            if (await settingsApi.SetCustomSettingAsync("preferences", preferences))
            {
                Console.WriteLine("Created custom settings: preferences");
            }

            // Retrieving custom settings names
            IEnumerable<string> names = await settingsApi.GetCustomSettingsAsync();
            string flatList = string.Join(", ", names);
            Console.WriteLine("Retrieved available setting names: [{0}]", flatList);

            // Retrieving preferences back
            UserPreferences instance = await settingsApi.GetCustomSettingAsync<UserPreferences>("preferences");
            Console.WriteLine("Retrieved preferences back:");
            Console.WriteLine("\tpreferences.flag={0}, preferences.entity.rank={1}", instance.Flag, instance.Entity.Rank);
        }

        internal class UserPreferences
        {
            public bool Flag { get; set; }
            public string[] Array { get; set; }
            public Entity Entity { get; set; }
        }


        internal class Entity
        {
            public int Rank { get; set; }
            public string Role { get; set; }
        }
    }
}
