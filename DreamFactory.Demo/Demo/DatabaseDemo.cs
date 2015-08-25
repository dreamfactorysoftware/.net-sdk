namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Builder;
    using DreamFactory.Model.Database;
    using DreamFactory.Rest;

    public class DatabaseDemo : IRunnable
    {
        private const string TableName = "staff";

        public async Task RunAsync(IRestContext context)
        {
            // Getting database interface
            IDatabaseApi databaseApi = context.Factory.CreateDatabaseApi("db");

            // List available tables
            List<string> tables = new List<string>(await databaseApi.GetTableNamesAsync());
            Console.WriteLine("Existing tables: {0}", tables.ToStringList());

            // Delete staff table if it exists
            if (tables.Contains(TableName))
            {
                Console.WriteLine("Deleting table {0}...", TableName);
                if (await databaseApi.DeleteTableAsync(TableName))
                {
                    Console.WriteLine("Table deleted.");
                }
            }

            Console.WriteLine("Creating {0} table schema...", TableName);
            TableSchema staffTableSchema = CreateTestTableSchema();
            await databaseApi.CreateTableAsync(staffTableSchema);

            // Describe table
            staffTableSchema = await databaseApi.DescribeTableAsync(TableName);
            Console.WriteLine("Got {0} table schema, table's label is {1}", TableName, staffTableSchema.label);

            // Create new record
            Console.WriteLine("Creating {0} records...", TableName);
            List<StaffRecord> records = CreateStaffRecords().ToList();
            records = new List<StaffRecord>(await databaseApi.CreateRecordsAsync(TableName, records, new SqlQuery()));

            SqlQuery query = new SqlQuery { filter = "age > 30", order = "age", fields = "*" };
            var selection = await databaseApi.GetRecordsAsync<StaffRecord>(TableName, query);
            var ages = selection.Select(x => x.age.ToString(CultureInfo.InvariantCulture)).ToStringList();
            Console.WriteLine("Get records with SqlQuery: ages={0}", ages);

            // Deleting one record
            Console.WriteLine("Deleting second record...");
            await databaseApi.DeleteRecordsAsync(TableName, records.Skip(1).Take(1));

            // Get table records
            records = new List<StaffRecord>(await databaseApi.GetRecordsAsync<StaffRecord>(TableName, new SqlQuery()));
            Console.WriteLine("Retrieved {0} records:", TableName);
            foreach (StaffRecord item in records)
            {
                Console.WriteLine("\t{0}", item);
            }
        }

        private static IEnumerable<StaffRecord> CreateStaffRecords()
        {
            yield return new StaffRecord { first_name = "Andrei", last_name = "Smirnov", age = 35, active = true };
            yield return new StaffRecord { first_name = "Mike", last_name = "Meyers", age = 33, active = false };
            yield return new StaffRecord { first_name = "Selena", last_name = "Gomez", age = 24, active = false };
        }

        private static TableSchema CreateTestTableSchema()
        {
            ITableSchemaBuilder builder = new TableSchemaBuilder();
            return builder.WithName(TableName).WithFieldsFrom<StaffRecord>().WithKeyField("uid").Build();
        }

        internal class StaffRecord
        {
            public int uid { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int age { get; set; }
            public bool active { get; set; }

            public override string ToString()
            {
                return string.Format("{0}: name = {1} {2}, age = {3}, active = {4}", uid, first_name, last_name, age, active);
            }
        }
    }
}
