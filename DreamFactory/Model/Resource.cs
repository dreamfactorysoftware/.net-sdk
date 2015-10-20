namespace DreamFactory.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Resource.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Name of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
