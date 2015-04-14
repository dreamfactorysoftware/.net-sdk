namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Email;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class EmailApiTests
    {
        private const string BaseAddress = "http://localhost";

        [TestMethod]
        public void ShouldSendEmailAsync()
        {
            // Arrange
            IEmailApi emailApi = CreateEmailApi();
            EmailRequest request = CreateEmailRequest();

            // Act
            int count = emailApi.SendEmailAsync(request).Result;

            // Assert
            count.ShouldBe(1);
        }

        private static IEmailApi CreateEmailApi()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            HttpHeaders headers = new HttpHeaders();
            return new EmailApi(address, httpFacade, new JsonContentSerializer(), headers, "email");
        }

        private static EmailRequest CreateEmailRequest()
        {
            EmailAddress address = new EmailAddress { email = "motodrug@gmail.com" };
            return new EmailRequest { to = new List<EmailAddress> { address }, subject = "Hello from the demo!", body_text = "Hello, moto!" };
        }
    }
}
