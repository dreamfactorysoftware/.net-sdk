namespace DreamFactory.Tests.Serialization
{
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class SnakeCasePropertyNameResolverTests
    {
        [TestMethod]
        public void ShouldResolveSingleWordPropertyName()
        {
            // Arrange
            var resolver = new SnakeCasePropertyNameResolver();
            var propertyName = "Uid";
            
            // Act
            string resolved = resolver.Resolve(propertyName);

            // Assert
            resolved.ShouldBe("uid");
        }

        [TestMethod]
        public void ShouldResolveMultipleWordPropertyName()
        {
            // Arrange
            var resolver = new SnakeCasePropertyNameResolver();
            var propertyName = "FirstName";

            // Act
            string resolved = resolver.Resolve(propertyName);

            // Assert
            resolved.ShouldBe("first_name");
        }

        [TestMethod]
        public void ShouldNotChangeAlreadySnakeCasePropertyName()
        {
            // Arrange
            var resolver = new SnakeCasePropertyNameResolver();
            var propertyName = "first_name";

            // Act
            string resolved = resolver.Resolve(propertyName);

            // Assert
            resolved.ShouldBe("first_name");
        }
    }
}