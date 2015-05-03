namespace DreamFactory.Demo.IntegrationTest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.System.User;
    using DreamFactory.Rest;

    public static class SystemUserTest
    {
        private const string NewEmail = "user@mail.com";

// ReSharper disable PossibleMultipleEnumeration
        public static async Task RunTest(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            IEnumerable<UserResponse> users = await systemApi.GetUsersAsync();
            Console.WriteLine("GetUsersAsync(): {0}", users.Select(x => x.display_name).ToStringList());

            UserResponse user = users.SingleOrDefault(x => x.email == NewEmail);
            if (user != null)
            {
                await DeleteUser(user, systemApi);
            }

            UserRequest newUser = new UserRequest
            {
                first_name = "Andrei",
                last_name = "Smirnov",
                display_name = "pinebit",
                email = NewEmail,
                password = "dream",
                is_active = true
            };

            // Creating new user
            users = await systemApi.CreateUsersAsync(newUser);
            user = users.Single(x => x.email == NewEmail);
            Console.WriteLine("CreateUsersAsync(): {0}", context.ContentSerializer.Serialize(user));

            await DeleteUser(user, systemApi);
        }

        private static async Task DeleteUser(UserResponse user, ISystemApi systemApi)
        {
            // Delete test user if it exists already
            Debug.Assert(user.id.HasValue, "User ID must be set");
            await systemApi.DeleteUsersAsync(user.id.Value);
            Console.WriteLine("DeleteUsersAsync():: id={0}", user.id);
        }
    }
}
