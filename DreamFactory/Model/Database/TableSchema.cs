namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;

    /// <summary>
    /// Table schema.
    /// </summary>
    public class TableSchema
    {
        /// <summary>
        /// Identifier/Name for the table.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Displayable singular name for the table.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Displayable plural name for the table.
        /// </summary>
        public string Plural { get; set; }

        /// <summary>
        /// Field(s), if any, that represent the primary key of each record.
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Field(s), if any, that represent the name of each record.
        /// </summary>
        public string NameField { get; set; }

        /// <summary>
        /// An array of available fields in each record.
        /// </summary>
        public List<FieldSchema> Field { get; set; }

        /// <summary>
        /// An array of available relationships to other tables.
        /// </summary>
        public List<RelatedSchema> Related { get; set; }
    }
}