namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
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

        #endregion

        private static IDatabaseApi CreateDatabaseApi(string alt = null)
        {
            IHttpFacade httpFacade = new TestDataHttpFacade(alt);
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            HttpHeaders headers = new HttpHeaders();
            return new DatabaseApi(address, httpFacade, new JsonContentSerializer(), headers, "db");
        }
    }
}