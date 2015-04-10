namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Rest;

    public class DatabaseDemo
    {
        public static async Task Run(string baseAddress)
        {
            // Login first
            IRestContext context = new RestContext(baseAddress);
            IUserSessionApi userSessionApi = context.Factory.CreateUserSessionApi();
            Session session = await userSessionApi.LoginAsync("todoangular", Utils.CreateLogin());
            Console.WriteLine("Logged in as {0}", session.display_name);

            // Get records
            IDatabaseApi databaseApi = context.Factory.CreateDatabaseApi("db");
            IEnumerable<TodoRecord> records = await databaseApi.GetRecordsAsync<TodoRecord>("todo");
            Console.WriteLine("todo records:");
            foreach (TodoRecord record in records)
            {
                Console.WriteLine("\tid={0}, complete={1}, name={2}, ", record.id, record.complete ? "Y" : "N", record.name);
            }
        }

        internal class TodoRecord
        {
            public int id { get; set; }

            public string name { get; set; }

            public bool complete { get; set; }
        }
    }
}