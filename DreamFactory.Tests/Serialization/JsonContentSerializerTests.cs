namespace DreamFactory.Tests.Serialization
{
    using System.Collections.Generic;
    using DreamFactory.Model;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class JsonContentSerializerTests
    {
        private const string TestJson = "{\"resource\":[{\"name\":\"foo\"},{\"name\":\"bar\"}]}";

        [TestMethod]
        public void ShouldSerializeObject()
        {
            // Arrange
            Resources resources = CreateTestObject();
            JsonContentSerializer serializer = new JsonContentSerializer();

            // Act
            string json = serializer.Serialize(resources);

            // Assert
            json.ShouldBe(TestJson);
        }

        [TestMethod]
        public void ShouldDeserializeObject()
        {
            // Arrange
            JsonContentSerializer serializer = new JsonContentSerializer();

            // Act
            Resources resources = serializer.Deserialize<Resources>(TestJson);

            // Assert
            serializer.Serialize(resources).ShouldBe(TestJson);
        }

        [TestMethod]
        public void ShouldDeserializeAnonymousObject()
        {
            // Arrange
            JsonContentSerializer serializer = new JsonContentSerializer();

            // Act
            var resource = new { resource = new List<Resource>() };
            resource = serializer.Deserialize(TestJson, resource);

            // Assert
            serializer.Serialize(resource).ShouldBe(TestJson);
        }

        private static Resources CreateTestObject()
        {
            Resource foo = new Resource { name = "foo" };
            Resource bar = new Resource { name = "bar" };
            return new Resources { resource = new List<Resource> { foo, bar } };
        }
    }
}