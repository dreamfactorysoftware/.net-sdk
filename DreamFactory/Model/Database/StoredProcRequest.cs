namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Stored procedure request.
    /// </summary>
    public class StoredProcRequest
    {
        /// <summary>
        /// Optional array of input and output parameters.
        /// </summary>
        [JsonProperty(PropertyName = "params")]
        public List<StoredProcParam> Params { get; set; }

        /// <summary>
        /// Add this wrapper around the expected data set before returning, same as URL parameter.
        /// </summary>
        [JsonProperty(PropertyName = "wrapper")]
        public string Wrapper { get; set; }
    }
}
