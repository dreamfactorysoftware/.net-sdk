namespace DreamFactory.Tests.Model
{
    using System.Linq;
    using DreamFactory.Model.Email;
    using DreamFactory.Model.Helper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class EmailRequestBuilderTests
    {
        [TestMethod]
        public void ShouldBuildEmailRequest()
        {
            // Arrange
            IEmailRequestBuilder builder = new EmailRequestBuilder()
                .AddTo("user@mail.com")
                .WithSubject("Hello")
                .WithBody("Hello, World!");

            // Act
            EmailRequest request = builder.Build();

            // Assert
            request.subject.ShouldBe("Hello");
            request.body_text.ShouldBe("Hello, World!");
            request.to.Single().email.ShouldBe("user@mail.com");
        }

    }
}
