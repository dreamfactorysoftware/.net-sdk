namespace DreamFactory.Tests.Model
{
    using System.Linq;
    using DreamFactory.Model.Builder;
    using DreamFactory.Model.Database;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class TableSchemaBuilderTests
    {
        [TestMethod]
        public void ShouldBuildWithName()
        {
            // Arrange
            ITableSchemaBuilder builder = new TableSchemaBuilder();

            // Act
            TableSchema schema = builder.WithName("name").Build();

            // Assert
            schema.name.ShouldBe("name");
        }

        [TestMethod]
        public void ShouldBuildWithKeyField()
        {
            // Arrange
            ITableSchemaBuilder builder = new TableSchemaBuilder();

            // Act
            TableSchema schema = builder.WithKeyField("index").Build();

            // Assert
            FieldSchema field = schema.field.First();
            field.is_primary_key.ShouldBe(true);
            field.type.ShouldBe("id");
            field.name.ShouldBe("index");
        }

        [TestMethod]
        public void ShouldBuildWithField()
        {
            // Arrange
            ITableSchemaBuilder builder = new TableSchemaBuilder();

            // Act
            TableSchema schema = builder.WithField("name", true, 123).Build();

            // Assert
            FieldSchema field = schema.field.First();
            field.is_primary_key.ShouldBe(null);
            field.required.ShouldBe(true);
            field.name.ShouldBe("name");
            field.default_value.ShouldBe("123");
        }

        [TestMethod]
        public void ShouldBuildWithFieldsFromRecord()
        {
            // Arrange
            ITableSchemaBuilder builder = new TableSchemaBuilder();

            // Act
            TableSchema schema = builder.WithFieldsFrom<Record>().Build();

            // Assert
            schema.field.Count.ShouldBe(4);
            schema.field.Single(x => x.name == "id").type.ShouldBe("id");
            schema.field.Single(x => x.name == "name").type.ShouldBe("string");
            schema.field.Single(x => x.name == "age").type.ShouldBe("integer");
            schema.field.Single(x => x.name == "active").type.ShouldBe("boolean");
        }

        private class Record
        {
            public int id { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public bool active { get; set; }
        }
    }
}