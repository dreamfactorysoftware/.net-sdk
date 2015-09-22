namespace DreamFactory.Tests.Model
{
    using System;
    using System.Linq;
    using DreamFactory.Model.Builder;
    using DreamFactory.Model.Email;
    using DreamFactory.Model.File;
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

            Should.Throw<ArgumentNullException>(() => builder.AddTo(null));
            Should.Throw<ArgumentNullException>(() => builder.WithSubject(null));
            Should.Throw<ArgumentNullException>(() => builder.WithBody(null));
        }

        [TestMethod]
        public void ShouldThrowIfNoRecipients()
        {
            // Arrange
            IEmailRequestBuilder builder = new EmailRequestBuilder()
                .WithSubject("Hello")
                .WithBody("Hello, World!");

            // Act & Assert
            Should.Throw<DreamFactoryException>(() => builder.Build());
        }

        [TestMethod]
        public void ShouldThrowIfNoTitle()
        {
            // Arrange
            IEmailRequestBuilder builder = new EmailRequestBuilder()
                .AddTo("user@mail.com")
                .WithBody("Hello, World!");

            // Act & Assert
            Should.Throw<DreamFactoryException>(() => builder.Build());
        }

        [TestMethod]
        public void ShouldThrowIfEmptyBody()
        {
            // Arrange
            IEmailRequestBuilder builder = new EmailRequestBuilder()
                .AddTo("user@mail.com")
                .WithSubject("Hello");

            // Act & Assert
            Should.Throw<DreamFactoryException>(() => builder.Build());
        }
    }
}
