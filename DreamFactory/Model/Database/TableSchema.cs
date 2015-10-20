namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Table schema.
    /// </summary>
    public class TableSchema
    {
        /// <summary>
        /// Identifier/Name for the table.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Displayable singular name for the table.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// Displayable plural name for the table.
        /// </summary>
        [JsonProperty(PropertyName = "plural")]
        public string Plural { get; set; }

        /// <summary>
        /// Field(s), if any, that represent the primary key of each record.
        /// </summary>
        [JsonProperty(PropertyName = "primary_key")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Field(s), if any, that represent the name of each record.
        /// </summary>
        [JsonProperty(PropertyName = "name_field")]
        public string NameField { get; set; }

        /// <summary>
        /// An array of available fields in each record.
        /// </summary>
        [JsonProperty(PropertyName = "field")]
        public List<FieldSchema> Field { get; set; }

        /// <summary>
        /// An array of available relationships to other tables.
        /// </summary>
        [JsonProperty(PropertyName = "related")]
        public List<RelatedSchema> Related { get; set; }
    }
}