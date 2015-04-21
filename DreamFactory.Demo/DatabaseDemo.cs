namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.Helper;
    using DreamFactory.Rest;

    public class DatabaseDemo
    {
        public static async Task Run(IRestContext context)
        {
            // Getting database interface
            IDatabaseApi databaseApi = context.Factory.CreateDatabaseApi("db");

            // List available tables
            List<string> tables = new List<string>(await databaseApi.GetTableNames(true));
            Console.WriteLine("Existing tables: {0}", tables.ToStringList());

            // Delete staff table if it exists
            if (tables.Contains("staff"))
            {
                Console.WriteLine("Deleting table staff...");
                if (await databaseApi.DeleteTableAsync("staff"))
                {
                    Console.WriteLine("Table staff deleted.");
                }
            }

            Console.WriteLine("Creating staff table schema...");
            TableSchema staffTableSchema = CreateTestTableSchema(); 
            await databaseApi.CreateTableAsync(staffTableSchema);

            // Describe table
            staffTableSchema = await databaseApi.DescribeTableAsync("staff");
            Console.WriteLine("Got staff table schema, table's label is {0}", staffTableSchema.label);

            // Create new record
            Console.WriteLine("Creating staff records...");
            IEnumerable<StaffRecord> records = CreateStaffRecords();
            await databaseApi.CreateRecordsAsync("staff", records);
            
            // Get staff records
            records = await databaseApi.GetRecordsAsync<StaffRecord>("staff");
            Console.WriteLine("Retrieved staff records:");
            foreach (StaffRecord item in records)
            {
                Console.WriteLine("\t{0}", item);
            }
        }

        private static IEnumerable<StaffRecord> CreateStaffRecords()
        {
            yield return new StaffRecord { first_name = "Andrei", last_name = "Smirnov", age = 35, active = true };
            yield return new StaffRecord { first_name = "John", last_name = "Smith", age = 33, active = false };
        }

        private static TableSchema CreateTestTableSchema()
        {
            ITableSchemaBuilder builder = new TableSchemaBuilder();
            return builder.WithName("staff").WithFieldsFrom<StaffRecord>().Build();
        }

        // ReSharper disable InconsistentNaming
        internal class StaffRecord
        {
            public int id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int age { get; set; }
            public bool active { get; set; }

            public override string ToString()
            {
                return string.Format("{0}: name = {1} {2}, age = {3}, active = {4}", id, first_name, last_name, age, active);
            }
        }
    }
}
