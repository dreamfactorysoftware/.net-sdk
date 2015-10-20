namespace DreamFactory.Model.System.Lookup
{
    using Newtonsoft.Json;

    /// <summary>
    /// LookupRequest.
    /// </summary>
    public class LookupRequest : IRecord
    {
        /// <summary>
        /// Identifier of this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Name for this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Value of this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Indicator whether this lookup is private.
        /// </summary>
        [JsonProperty(PropertyName = "private")]
        public bool? Private { get; set; }

        /// <summary>
        /// Description for this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
