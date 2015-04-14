namespace DreamFactory.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using DreamFactory.Model.Database;

    /// <summary>
    /// <see cref="TableSchema"/> builder.
    /// </summary>
    public class TableSchemaBuilder : ITableSchemaBuilder
    {
        private readonly List<FieldSchema> fields;

        private readonly Dictionary<Type, string> types;

        private string tableName;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableSchemaBuilder"/> class.
        /// </summary>
        public TableSchemaBuilder()
        {
            fields = new List<FieldSchema>();
            types = new Dictionary<Type, string>
            {
                { typeof (string), "string" },
                { typeof (int), "integer" },
                { typeof (long), "integer" },
                { typeof (bool), "boolean" },
                { typeof (byte[]), "binary" },
                { typeof (float), "float" },
                { typeof (double), "double" },
                { typeof (decimal), "decimal" },
                { typeof (DateTime), "datetime" },
            };
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
            string typeName = GetFieldTypeName(typeof (TField));

            FieldSchema field = new FieldSchema
            {
                name = fieldName,
                required = required,
                default_value = defaultValue.ToString().ToLowerInvariant(),
                type = typeName
            };

            fields.Add(field);
            return this;
        }

        /// <inheritdoc />
        public ITableSchemaBuilder WithKeyField(string fieldName)
        {
            FieldSchema field = new FieldSchema
            {
                name = fieldName,
                required = true,
                type = "id",
                is_primary_key = true,
                auto_increment = true
            };

            fields.Add(field);
            return this;
        }

        /// <inheritdoc />
        public ITableSchemaBuilder WithFieldsFrom<TRecord>() where TRecord : class, new()
        {
            PropertyInfo[] properties = typeof(TRecord).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (string.Compare(propertyInfo.Name, "id", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    if (!propertyInfo.PropertyType.IsValueType)
                    {
                        throw new NotSupportedException("Field 'id' must be of a value type");
                    }

                    WithKeyField(propertyInfo.Name);
                    continue;
                }

                string typeName = GetFieldTypeName(propertyInfo.PropertyType);

                FieldSchema field = new FieldSchema
                {
                    name = propertyInfo.Name,
                    required = false,
                    type = typeName
                };

                fields.Add(field);
            }

            return this;
        }

        /// <inheritdoc />
        public TableSchema Build()
        {
            return new TableSchema { name = tableName, field = fields };
        }

        private string GetFieldTypeName(Type fieldType)
        {
            string typeName;
            if (!types.TryGetValue(fieldType, out typeName))
            {
                throw new NotSupportedException("Field type is not supported: " + fieldType.Name);
            }

            return typeName;
        }
    }
}
