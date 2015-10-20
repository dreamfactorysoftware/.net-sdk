namespace DreamFactory.Model
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Wrapper for request resources.
    /// </summary>
    /// <typeparam name="T">Type of the records.</typeparam>
    public class RequestResourceWrapper<T> : ResourceWrapper<T>
    {
        /// <summary>
        /// Collection of identifiers.
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public int?[] Ids { get; set; }
    }
}
