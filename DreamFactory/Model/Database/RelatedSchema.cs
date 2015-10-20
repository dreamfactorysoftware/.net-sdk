namespace DreamFactory.Model.Database
{
    using Newtonsoft.Json;

    /// <summary>
    /// Related schema.
    /// </summary>
    public class RelatedSchema
    {
        /// <summary>
        /// Name of the relationship.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Relationship type - belongs_to, has_many, many_many.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The table name that is referenced by the relationship.
        /// </summary>
        [JsonProperty(PropertyName = "ref_table")]
        public string RefTable { get; set; }

        /// <summary>
        /// The field name that is referenced by the relationship. 
        /// </summary>
        [JsonProperty(PropertyName = "ref_field")]
        public string RefField { get; set; }

        /// <summary>
        /// The intermediate joining table used for many_many relationships.
        /// </summary>
        [JsonProperty(PropertyName = "join")]
        public string Join { get; set; }

        /// <summary>
        /// The current table field that is used in the relationship.
        /// </summary>
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }
    }
}
