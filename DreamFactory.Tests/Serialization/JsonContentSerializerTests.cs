﻿namespace DreamFactory.Tests.Serialization
{
    using System;
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
            var resources = new { resource = CreateTestObject() };
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
            var resource = serializer.Deserialize<Resource>("{\"name\":\"foo\"}");

            // Assert
            serializer.Serialize(resource).ShouldBe("{\"name\":\"foo\"}");
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

        [TestMethod]
        public void ShouldThrowExceptionOnSerialization()
        {
            // Arrange
            JsonContentSerializer serializer = new JsonContentSerializer();

            // Act & Assert
            Should.Throw<ArgumentNullException>(() => serializer.Serialize((object)null));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnDeserialization()
        {
            // Arrange
            JsonContentSerializer serializer = new JsonContentSerializer();

            // Act
            var resource = new { resource = new List<Resource>() };

            // Act & Assert
            Should.Throw<ArgumentNullException>(() => serializer.Deserialize(null, resource));
            Should.Throw<ArgumentNullException>(() => serializer.Deserialize<object>((string)null));
        }

        private static IEnumerable<Resource> CreateTestObject()
        {
            yield return new Resource { Name = "foo" };
            yield return new Resource { Name = "bar" };
        }
    }
}