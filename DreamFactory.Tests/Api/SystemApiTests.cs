namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model.System;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class SystemApiTests
    {
        private const string BaseAddress = "http://localhost";

        [TestMethod]
        public void ShouldGetAppsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<AppResponse> apps = systemApi.GetAppsAsync().Result.ToList();

            // Assert
            apps.Count.ShouldBe(4);
        }

        private static ISystemApi CreateSystemApi(string suffix = null)
        {
            HttpHeaders headers;
            return CreateSystemApi(out headers, suffix);
        }

        private static ISystemApi CreateSystemApi(out HttpHeaders headers, string suffix = null)
        {
            IHttpFacade httpFacade = new TestDataHttpFacade(suffix);
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            headers = new HttpHeaders();
            return new SystemApi(address, httpFacade, new JsonContentSerializer(), headers);
        }
 
    }
}