namespace DreamFactory.Tests.Api
{
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
        private const string BaseAddress = "http://localhost";

        #region --- Schema ---

        [TestMethod]
        public void ShouldGetAccessComponentsAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            List<TableInfo> result = databaseApi.GetAccessComponentsAsync().Result.ToList();

            // Assert
            result.Count.ShouldBe(3);
            result.Any(x => x.name == "todo").ShouldBe(true);
        }

        [TestMethod]
        public void ShouldGetTableNamesAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi("alt");

            // Act
            List<string> names = databaseApi.GetTableNamesAsync(true).Result.ToList();

            // Assert
            names.Count.ShouldBe(7);
            names.ShouldContain("todo");
            names.ShouldContain("_schema/todo");
        }

        [TestMethod]
        public void ShouldCreateTableAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            TableSchema schema = CreateTestTableSchema();

            // Act & Assert
            databaseApi.CreateTableAsync(schema).Wait();
        }

        [TestMethod]
        public void ShouldUpdateTableAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();
            TableSchema schema = CreateTestTableSchema();

            // Act & Assert
            databaseApi.UpdateTableAsync(schema).Wait();
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
        }

        [TestMethod]
        public void ShouldDescribeTableAsync()
        {
            // Arrange
            IDatabaseApi databaseApi = CreateDatabaseApi();

            // Act
            TableSchema schema = databaseApi.DescribeTableAsync("staff").Result;

            // Assert
            schema.name.ShouldBe("staff");
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

        // ReSharper disable InconsistentNaming
        internal class StaffRecord
        {
            public int uid { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int age { get; set; }
            public bool active { get; set; }
        }
    }
}