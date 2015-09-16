namespace DreamFactory.Model
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Wrapper for resources.
    /// </summary>
    /// <typeparam name="T">Type of the records.</typeparam>
    public class ResourceWrapper<T>
    {
        /// <summary>
        /// Collection of records.
        /// </summary>
        [JsonProperty(PropertyName = "resource")]
        public List<T> Records { get; set; }
    }
}
