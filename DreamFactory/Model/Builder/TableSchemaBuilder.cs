namespace DreamFactory.Model.Builder
{
    using DreamFactory.Model.Database;
    using DreamFactory.Serialization;
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Reflection;

    /// <summary>
    /// <see cref="TableSchema"/> builder.
    /// </summary>
    public class TableSchemaBuilder : ITableSchemaBuilder
    {
        private readonly List<FieldSchema> fields;

        private string tableName;
        private readonly IPropertyNameResolver propertyNameResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableSchemaBuilder"/> class.
        /// </summary>
        public TableSchemaBuilder()
        {
            fields = new List<FieldSchema>();
            propertyNameResolver = new SnakeCasePropertyNameResolver();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableSchemaBuilder"/> class.
        /// <param name="propertyNameResolver">Resolver to be used when serializing property names.</param>
        /// </summary>
        public TableSchemaBuilder(IPropertyNameResolver propertyNameResolver)
        {
            fields = new List<FieldSchema>();
            this.propertyNameResolver = propertyNameResolver;
        }

        /// <inheritdoc />
        public ITableSchemaBuilder WithName(string name)
        {
            tableName = name;
            return this;
        }

        /// <inheritdoc />
        public ITableSchemaBuilder WithField<TField>(string fieldName, bool required = false, TField defaultValue = default(TField))
        {
            string typeName = TypeMap.GetTypeName(typeof (TField));

            FieldSchema field = new FieldSchema
            {
                Name = fieldName,
                Required = required,
                DefaultValue = defaultValue.ToString().ToLowerInvariant(),
                Type = typeName
            };

            fields.Add(field);
            return this;
        }

        /// <inheritdoc />
        public ITableSchemaBuilder WithKeyField(string fieldName)
        {
            FieldSchema field = new FieldSchema
            {
                Name = fieldName,
                Required = true,
                Type = "id",
                IsPrimaryKey = true,
                AutoIncrement = true
            };

            fields.Add(field);
            return this;
        }

        /// <inheritdoc />
        public ITableSchemaBuilder WithFieldsFrom<TRecord>() where TRecord : class, new()
        {
            IEnumerable<PropertyInfo> properties = (typeof(TRecord)).GetTypeInfo().DeclaredProperties;
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (string.Compare(propertyNameResolver.Resolve(propertyInfo.Name), "id", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (!propertyInfo.PropertyType.GetTypeInfo().IsValueType)
                    {
                        throw new NotSupportedException("Field 'id' must be of a value type");
                    }

                    WithKeyField(propertyNameResolver.Resolve(propertyInfo.Name));
                    continue;
                }

                string typeName = TypeMap.GetTypeName(propertyInfo.PropertyType);

                FieldSchema field = new FieldSchema
                {
                    Name = propertyNameResolver.Resolve(propertyInfo.Name),
                    Required = false,
                    Type = typeName
                };

                fields.Add(field);
            }

            return this;
        }

        /// <inheritdoc />
        public TableSchema Build()
        {
            return new TableSchema { Name = tableName, Field = fields };
        }
    }
}
