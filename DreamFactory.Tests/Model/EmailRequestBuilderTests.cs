namespace DreamFactory.Tests.Model
{
    using System.Linq;
    using DreamFactory.Model.Builder;
    using DreamFactory.Model.Email;
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
            request.Subject.ShouldBe("Hello");
            request.BodyText.ShouldBe("Hello, World!");
            request.To.Single().Email.ShouldBe("user@mail.com");
        }

    }
}
