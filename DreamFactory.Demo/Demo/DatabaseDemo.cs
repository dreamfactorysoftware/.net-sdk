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
        private const string ServiceName = "db3";

        public async Task RunAsync(IRestContext context)
        {
            // Getting database interface
            IDatabaseApi databaseApi = context.Factory.CreateDatabaseApi(ServiceName);

            // List available tables
            IEnumerable<TableInfo> tables = (await databaseApi.GetTableNamesAsync()).ToList();
            Console.WriteLine("Existing tables: {0}", tables.Select(x => x.Name).ToStringList());

            // Delete staff table if it exists
            if (tables.Any(x => x.Name == TableName))
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
            Console.WriteLine("Got {0} table schema, table's label is {1}", TableName, staffTableSchema.Label);

            // Create new record
            Console.WriteLine("Creating {0} records...", TableName);
            List<StaffRecord> records = CreateStaffRecords().ToList();
            records = (await databaseApi.CreateRecordsAsync(TableName, records, new SqlQuery())).Records;

            // Update record
            Console.WriteLine("Creating {0} records...", TableName);
            StaffRecord firstRecord = records.First();
            firstRecord.FirstName = "Andrei 2";
            await databaseApi.UpdateRecordsAsync(TableName, records, new SqlQuery());

            SqlQuery query = new SqlQuery { Filter = "age > 30", Order = "age", Fields = "*" };
            IEnumerable<StaffRecord> selection = (await databaseApi.GetRecordsAsync<StaffRecord>(TableName, query)).Records;
            string ages = selection.Select(x => x.Age.ToString(CultureInfo.InvariantCulture)).ToStringList();
            Console.WriteLine("Get records with SqlQuery: ages={0}", ages);

            // Deleting one record
            Console.WriteLine("Deleting second record...");
            await databaseApi.DeleteRecordsAsync(TableName, records.Skip(1).Take(1), new SqlQuery());

            // Get table records
            records = (await databaseApi.GetRecordsAsync<StaffRecord>(TableName, new SqlQuery())).Records;
            Console.WriteLine("Retrieved {0} records:", TableName);
            foreach (StaffRecord item in records)
            {
                Console.WriteLine("\t{0}", item);
            }
        }

        private static IEnumerable<StaffRecord> CreateStaffRecords()
        {
            yield return new StaffRecord { FirstName = "Andrei", LastName = "Smirnov", Age = 35, Active = true };
            yield return new StaffRecord { FirstName = "Mike", LastName = "Meyers", Age = 33, Active = false };
            yield return new StaffRecord { FirstName = "Selena", LastName = "Gomez", Age = 24, Active = false };
        }

        private static TableSchema CreateTestTableSchema()
        {
            ITableSchemaBuilder builder = new TableSchemaBuilder();
            return builder.WithName(TableName).WithFieldsFrom<StaffRecord>().WithKeyField("uid").Build();
        }

        internal class StaffRecord
        {
            public int Uid { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public bool Active { get; set; }

            public override string ToString()
            {
                return string.Format("{0}: name = {1} {2}, age = {3}, active = {4}", Uid, FirstName, LastName, Age, Active);
            }
        }
    }
}
