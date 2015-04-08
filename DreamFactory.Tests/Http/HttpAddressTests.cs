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
            HttpAddress addressV1 = new HttpAddress("http://localhost", RestApiVersion.V1, resources, parameters);
            HttpAddress addressV2 = new HttpAddress("http://localhost", RestApiVersion.V2, resources, parameters);

            // Assert
            addressV1.Build().ShouldBe("http://localhost/rest/user/session?one=1&two=true");
            addressV2.Build().ShouldBe("http://localhost/api/v2.0/user/session?one=1&two=true");
        }

        [TestMethod]
        public void ShouldChangeVersion()
        {
            // Arrange
            HttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithVersion(RestApiVersion.V2);

            // Assert
            address.Build().ShouldBe("http://localhost/api/v2.0/user/session?one=1&two=true");
        }

        [TestMethod]
        public void ShouldChangeResources()
        {
            // Arrange
            HttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithResources("system", "config");

            // Assert
            address.Build().ShouldBe("http://localhost/rest/system/config?one=1&two=true");
        }

        [TestMethod]
        public void ShouldAddParameters()
        {
            // Arrange
            HttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithParameter("new", "value");

            // Assert
            address.Build().ShouldBe("http://localhost/rest/user/session?one=1&two=true&new=value");
        }

        [TestMethod]
        public void ShouldChangeBaseAddress()
        {
            // Arrange
            HttpAddress address = CreateTestHttpAddress();

            // Act
            address = address.WithBaseAddress("https://pinebit.ddns.net");

            // Assert
            address.Build().ShouldBe("https://pinebit.ddns.net/rest/user/session?one=1&two=true");
        }

        [TestMethod]
        public void ShouldNotModifyOriginal()
        {
            // Arrange
            HttpAddress address = CreateTestHttpAddress();
            string result = address.Build();

            // Act
            address
                .WithVersion(RestApiVersion.V2).WithResources("system", "config")
                .WithBaseAddress("https://pinebit.ddns.net")
                .WithParameter("new", "value");

            // Assert
            address.Build().ShouldBe(result);
        }

        private static HttpAddress CreateTestHttpAddress()
        {
            List<string> resources = new List<string> { "user", "session" };
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "one", 1 },
                { "two", true }
            };

            return new HttpAddress("http://localhost", RestApiVersion.V1, resources, parameters);
        }
    }
}
