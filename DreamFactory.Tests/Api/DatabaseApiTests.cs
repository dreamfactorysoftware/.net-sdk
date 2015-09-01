namespace DreamFactory.Tests.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model.Builder;
    using DreamFactory.Model.Database;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class DatabaseApiTests
    {
        private const string BaseAddress = "http://localhost:8765";

        #region --- Schema ---

        [TestMethod]
        public void ShouldGetAccessComponentsAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            List<TableInfo> result = databaseApi.GetAccessComponentsAsync().Result.ToList();

            // Assert
            result.Count.ShouldBe(4);
            result.Any(x => x.Name == "_table").ShouldBe(true);
        }

        [TestMethod]
        public void ShouldGetTableNamesAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            List<string> names = databaseApi.GetTableNamesAsync(true).Result.Select(x => x.Name).ToList();

            // Assert
            names.Count.ShouldBe(3);
            names.ShouldContain("todo");
        }

        [TestMethod]
        public void ShouldCreateTableAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            TableSchema schema = CreateTestTableSchema();

            // Act & Assert
            databaseApi.CreateTableAsync(schema).Wait();

            Should.Throw<ArgumentNullException>(() => databaseApi.CreateTableAsync(null));
        }

        [TestMethod]
        public void ShouldUpdateTableAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            TableSchema schema = CreateTestTableSchema();

            // Act & Assert
            databaseApi.UpdateTableAsync(schema).Wait();

            Should.Throw<ArgumentNullException>(() => databaseApi.UpdateTableAsync(null));
        }

        [TestMethod]
        public void ShouldDeleteTableAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            bool success = databaseApi.DeleteTableAsync("staff").Result;

            // Assert
            success.ShouldBe(true);

            Should.Throw<ArgumentNullException>(() => databaseApi.DeleteTableAsync(null));
        }

        [TestMethod]
        public void ShouldDescribeTableAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            TableSchema schema = databaseApi.DescribeTableAsync("staff").Result;

            // Assert
            schema.Name.ShouldBe("staff");

            Should.Throw<ArgumentNullException>(() => databaseApi.DescribeTableAsync(null));
        }

        [TestMethod]
        public void ShouldDescribeFieldAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            FieldSchema schema = databaseApi.DescribeFieldAsync("staff", "field").Result;

            // Assert
            schema.Name.ShouldBe("field");

            Should.Throw<ArgumentNullException>(() => databaseApi.DescribeFieldAsync(null, "field"));
            Should.Throw<ArgumentNullException>(() => databaseApi.DescribeFieldAsync("staff", null));
        }

        #endregion

        #region --- Records ---

        [TestMethod]
        public void ShouldCreateRecordsAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            IEnumerable<StaffRecord> records = CreateStaffRecords().ToList();
            SqlQuery query = new SqlQuery { Fields = "*" };

            // Act
            List<StaffRecord> created = databaseApi.CreateRecordsAsync("staff", records, query).Result.ToList();

            // Assert
            created.Count.ShouldBe(3);
            created.First().Uid.ShouldBe(1);
            created.Last().Uid.ShouldBe(3);

            Should.Throw<ArgumentNullException>(() => databaseApi.CreateRecordsAsync(null, records, query));
            Should.Throw<ArgumentNullException>(() => databaseApi.CreateRecordsAsync("staff", (List<StaffRecord>)null, query));
            Should.Throw<ArgumentNullException>(() => databaseApi.CreateRecordsAsync("staff", records, null));
        }

        [TestMethod]
        public void ShouldUpdateRecordsAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            IEnumerable<StaffRecord> records = CreateStaffRecords().Skip(1).ToList();

            // Act & Assert
            databaseApi.UpdateRecordsAsync("staff", records).Wait();

            Should.Throw<ArgumentNullException>(() => databaseApi.UpdateRecordsAsync(null, records));
            Should.Throw<ArgumentNullException>(() => databaseApi.UpdateRecordsAsync("staff", (List<StaffRecord>)null));
        }

        [TestMethod]
        public void ShouldGetRecordsAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            SqlQuery query = new SqlQuery { Fields = "*" };

            // Act
            List<StaffRecord> records = databaseApi.GetRecordsAsync<StaffRecord>("staff", query).Result.ToList();

            // Assert
            records.Count.ShouldBe(3);
            records.First().Uid.ShouldBe(1);
            records.Last().Uid.ShouldBe(3);

            Should.Throw<ArgumentNullException>(() => databaseApi.GetRecordsAsync<StaffRecord>(null, query));
            Should.Throw<ArgumentNullException>(() => databaseApi.GetRecordsAsync<StaffRecord>("staff", null));
        }

        [TestMethod]
        public void ShouldDeleteRecordsAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            IEnumerable<StaffRecord> records = CreateStaffRecords().Take(1).ToList();

            // Act & Assert
            databaseApi.DeleteRecordsAsync("staff", records).Wait();

            Should.Throw<ArgumentNullException>(() => databaseApi.DeleteRecordsAsync(null, records));
            Should.Throw<ArgumentNullException>(() => databaseApi.DeleteRecordsAsync("staff", (List<StaffRecord>)null));
        }

        #endregion

        #region --- Stored ---

        [TestMethod]
        public void ShouldGetStoredProcNamesAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            List<string> names = databaseApi.GetStoredProcNamesAsync().Result.ToList();

            // Assert
            names.Count.ShouldBe(2);
            names.First().ShouldBe("foo");
        }

        [TestMethod]
        public void ShouldGetStoredFuncNamesAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            List<string> names = databaseApi.GetStoredFuncNamesAsync().Result.ToList();

            // Assert
            names.Count.ShouldBe(2);
            names.First().ShouldBe("bar");
        }

        [TestMethod]
        public void ShouldCallStoredProcAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            IStoreProcParamsBuilder builder =
                new StoreProcParamsBuilder()
                    .WithOutParam<string>("bar")
                    .WithOutParam<int>("foo");
            StoredProcParam[] parameters = builder.Build();

            // Act
            ProcResponse result = databaseApi.CallStoredProcAsync<ProcResponse>("foo", "dataset", parameters).Result;

            // Assert
            result.Foo.ShouldBe(123);
            result.Bar.ShouldBe("test");
            result.Dataset.Count.ShouldBe(2);
            result.Dataset.Any(x => x.FirstName == "Selena").ShouldBe(true);

            Should.Throw<ArgumentNullException>(() => databaseApi.CallStoredProcAsync(null, parameters));
            Should.Throw<ArgumentNullException>(() => databaseApi.CallStoredProcAsync<ProcResponse>(null, parameters));
            Should.Throw<ArgumentNullException>(() => databaseApi.CallStoredProcAsync<ProcResponse>(null, "dataset", parameters));
            Should.Throw<ArgumentNullException>(() => databaseApi.CallStoredProcAsync<ProcResponse>("foo", null, parameters));
        }

        [TestMethod]
        public void ShouldCallStoredFuncAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            IStoreProcParamsBuilder builder =
                new StoreProcParamsBuilder()
                    .WithOutParam<string>("bar")
                    .WithOutParam<int>("foo");
            StoredProcParam[] parameters = builder.Build();

            // Act
            ProcResponse result = databaseApi.CallStoredFuncAsync<ProcResponse>("foo", "dataset", parameters).Result;

            // Assert
            result.Foo.ShouldBe(123);
            result.Bar.ShouldBe("test");
            result.Dataset.Count.ShouldBe(2);
            result.Dataset.Any(x => x.FirstName == "Selena").ShouldBe(true);

            Should.Throw<ArgumentNullException>(() => databaseApi.CallStoredFuncAsync<ProcResponse>(null, parameters));
            Should.Throw<ArgumentNullException>(() => databaseApi.CallStoredFuncAsync<ProcResponse>(null, "dataset", parameters));
            Should.Throw<ArgumentNullException>(() => databaseApi.CallStoredFuncAsync<ProcResponse>("foo", null, parameters));
        }

        #endregion

        private static IDatabaseApi CreateDatabaseApi(string alt = null)
        {
            IHttpFacade httpFacade = new TestDataHttpFacade(alt);
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            HttpHeaders headers = new HttpHeaders();
            return new DatabaseApi(address, httpFacade, new JsonContentSerializer(), headers, "db");
        }

        private static TableSchema CreateTestTableSchema()
        {
            ITableSchemaBuilder builder = new TableSchemaBuilder();
            return builder.WithName("staff").WithFieldsFrom<StaffRecord>().WithKeyField("uid").Build();
        }

        private static IEnumerable<StaffRecord> CreateStaffRecords()
        {
            yield return new StaffRecord { FirstName = "Andrei", LastName = "Smirnov", Age = 35, Active = true };
            yield return new StaffRecord { FirstName = "Mike", LastName = "Meyers", Age = 33, Active = false };
            yield return new StaffRecord { FirstName = "Selena", LastName = "Gomez", Age = 24, Active = false };
        }

        internal class StaffRecord
        {
            public int Uid { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public bool Active { get; set; }
        }

        internal class ProcResponse
        {
            public List<StaffRecord> Dataset { get; set; }
            public int Foo { get; set; }
            public string Bar { get; set; }
        }
    }
}