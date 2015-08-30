namespace DreamFactory.Demo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.User;
    using DreamFactory.Rest;

    public class SystemUserTest : IRunnable
    {
        private const string NewEmail = "user@mail.com";

        public async Task RunAsync(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            IEnumerable<UserResponse> users = (await systemApi.GetUsersAsync(new SqlQuery())).ToList();
            Console.WriteLine("GetUsersAsync(): {0}", users.Select(x => x.DisplayName).ToStringList());

            UserResponse user = users.SingleOrDefault(x => x.Email == NewEmail);
            if (user != null)
            {
                await DeleteUser(user, systemApi);
            }

            UserRequest newUser = new UserRequest
            {
                FirstName = "Andrei",
                LastName = "Smirnov",
                DisplayName = "pinebit",
                Email = NewEmail,
                Password = "dream",
                IsActive = true
            };

            users = await systemApi.CreateUsersAsync(new SqlQuery(), newUser);
            user = users.Single(x => x.Email == NewEmail);
            Console.WriteLine("CreateUsersAsync(): {0}", context.ContentSerializer.Serialize(user));

            newUser.Id = user.Id;
            newUser.DisplayName = "Andrei Smirnov";
            user = (await systemApi.UpdateUsersAsync(new SqlQuery(), newUser)).Single(x => x.Email == NewEmail);
            Console.WriteLine("UpdateUsersAsync(): new display_name={0}", user.DisplayName);

            await DeleteUser(user, systemApi);
        }

        private static async Task DeleteUser(UserResponse user, ISystemApi systemApi)
        {
            Debug.Assert(user.Id.HasValue, "User ID must be set");
            await systemApi.DeleteUsersAsync(new SqlQuery(), user.Id.Value);
            Console.WriteLine("DeleteUsersAsync():: id={0}", user.Id);
        }
    }
}
