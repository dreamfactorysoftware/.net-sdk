namespace DreamFactory.Tests.Http
{
    using System.Collections.Generic;
    using DreamFactory.Http;
    using DreamFactory.Rest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class HttpAddressTests
    {
        [TestMethod]
        public void ShouldBuildAfterConstruction()
        {
            // Arrange
            List<string> resources = new List<string> { "user", "session" };
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "one", 1 },
                { "two", true }
            };

            // Act
            HttpAddress addressV1 = new HttpAddress("http://localhost:8765", RestApiVersion.V1, resources, parameters);
            HttpAddress addressV2 = new HttpAddress("http://localhost:8765", RestApiVersion.V2, resources, parameters);

            // Assert
            addressV1.Build().ShouldBe("http://localhost:8765/rest/user/session?one=1&two=true");
            addressV2.Build().ShouldBe("http://localhost:8765/api/v2/user/session?one=1&two=true");
        }

        [TestMethod]
        public void ShouldChangeVersion()
        {
            // Arrange
            IHttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithVersion(RestApiVersion.V2);

            // Assert
            address.Build().ShouldBe("http://localhost:8765/api/v2/user/session?one=1&two=true");
        }

        [TestMethod]
        public void ShouldAddResources()
        {
            // Arrange
            IHttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithResource("add");

            // Assert
            address.Build().ShouldBe("http://localhost:8765/rest/user/session/add?one=1&two=true");
        }

        [TestMethod]
        public void ShouldAddParameters()
        {
            // Arrange
            IHttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithParameter("new", "value");

            // Assert
            address.Build().ShouldBe("http://localhost:8765/rest/user/session?one=1&two=true&new=value");
        }

        [TestMethod]
        public void ShouldChangeBaseAddress()
        {
            // Arrange
            IHttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithBaseAddress("https://pinebit.ddns.net");

            // Assert
            address.Build().ShouldBe("https://pinebit.ddns.net/rest/user/session?one=1&two=true");
        }

        [TestMethod]
        public void ShouldNotModifyOriginal()
        {
            // Arrange
            IHttpAddress address = CreateTestHttpAddress();
            string result = address.Build();

            // Act
            address
                .WithVersion(RestApiVersion.V2).WithResource("system", "config")
                .WithBaseAddress("https://pinebit.ddns.net")
                .WithParameter("new", "value");

            // Assert
            address.Build().ShouldBe(result);
        }

        private static IHttpAddress CreateTestHttpAddress()
        {
            List<string> resources = new List<string> { "user", "session" };
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "one", 1 },
                { "two", true }
            };

            return new HttpAddress("http://localhost:8765", RestApiVersion.V1, resources, parameters);
        }
    }
}
