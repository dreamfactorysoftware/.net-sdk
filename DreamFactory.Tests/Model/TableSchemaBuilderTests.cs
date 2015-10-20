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
            schema.Name.ShouldBe("name");
        }

        [TestMethod]
        public void ShouldBuildWithKeyField()
        {
            // Arrange
            ITableSchemaBuilder builder = new TableSchemaBuilder();

            // Act
            TableSchema schema = builder.WithKeyField("index").Build();

            // Assert
            FieldSchema field = schema.Field.First();
            field.IsPrimaryKey.ShouldBe(true);
            field.Type.ShouldBe("id");
            field.Name.ShouldBe("index");
        }

        [TestMethod]
        public void ShouldBuildWithField()
        {
            // Arrange
            ITableSchemaBuilder builder = new TableSchemaBuilder();

            // Act
            TableSchema schema = builder.WithField("name", true, 123).Build();

            // Assert
            FieldSchema field = schema.Field.First();
            field.IsPrimaryKey.ShouldBe(null);
            field.Required.ShouldBe(true);
            field.Name.ShouldBe("name");
            field.DefaultValue.ShouldBe("123");
        }

        [TestMethod]
        public void ShouldBuildWithFieldsFromRecord()
        {
            // Arrange
            ITableSchemaBuilder builder = new TableSchemaBuilder();

            // Act
            TableSchema schema = builder.WithFieldsFrom<Record>().Build();

            // Assert
            schema.Field.Count.ShouldBe(4);
            schema.Field.Single(x => x.Name == "Id").Type.ShouldBe("id");
            schema.Field.Single(x => x.Name == "Name").Type.ShouldBe("string");
            schema.Field.Single(x => x.Name == "Age").Type.ShouldBe("integer");
            schema.Field.Single(x => x.Name == "Active").Type.ShouldBe("boolean");
        }

        private class Record
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public bool Active { get; set; }
        }
    }
}