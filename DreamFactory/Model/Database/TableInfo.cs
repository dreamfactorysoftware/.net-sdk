namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A table information.
    /// </summary>
    public class TableInfo
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
        /// List of allowed HTTP verbs.
        /// </summary>
        [JsonProperty(PropertyName = "access")]
        public List<string> Access { get; set; }
    }
}
