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
                flag = true,
                array = new[] { "a", "b", "c" },
                entity = new UserPreferences.Entity { rank = 4, role = "user" }
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
            Console.WriteLine("\tpreferences.flag={0}, preferences.entity.rank={1}", instance.flag, instance.entity.rank);
        }

        internal class UserPreferences
        {
            public bool flag { get; set; }
            public string[] array { get; set; }
            public Entity entity { get; set; }

            internal class Entity
            {
                public int rank { get; set; }
                public string role { get; set; }
            }
        }
    }
}
