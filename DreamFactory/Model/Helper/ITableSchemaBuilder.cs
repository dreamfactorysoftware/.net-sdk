namespace DreamFactory.Model.Helper
{
    using DreamFactory.Model.Database;

    /// <summary>
    /// Represents <see cref="TableSchema"/> builder.
    /// </summary>
    public interface ITableSchemaBuilder
    {
        /// <summary>
        /// Sets table's name.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>Interface chaining.</returns>
        ITableSchemaBuilder WithName(string tableName);

        /// <summary>
        /// Adds a new field.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="required">True if the field is required.</param>
        /// <param name="defaultValue">Field's default value.</param>
        /// <typeparam name="TField">Type of the field.</typeparam>
        /// <returns>Interface chaining.</returns>
        ITableSchemaBuilder WithField<TField>(string fieldName, bool required = false, TField defaultValue = default(TField));

        /// <summary>
        /// Adds the primary key field of type 'id'. 
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>Interface chaining.</returns>
        ITableSchemaBuilder WithKeyField(string fieldName);

        /// <summary>
        /// Add fields from a POCO class properties using reflection.
        /// </summary>
        /// <remarks>
        /// See POCO term definition for TRecord class requirements.
        /// A field named 'id' of an integer type becomes the primary key.
        /// </remarks>
        /// <typeparam name="TRecord">Type of the POCO class.</typeparam>
        /// <returns>Interface chaining.</returns>
        ITableSchemaBuilder WithFieldsFrom<TRecord>() where TRecord : class, new();

        /// <summary>
        /// Builds resulting <see cref="TableSchema"/>.
        /// </summary>
        /// <returns><see cref="TableSchema"/> instance.</returns>
        TableSchema Build();
    }
}
