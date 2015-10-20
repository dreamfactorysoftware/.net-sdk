namespace DreamFactory.Model.System.Custom
{
    using Newtonsoft.Json;

    /// <summary>
    /// CustomRequest.
    /// </summary>
    public class CustomRequest
    {
        /// <summary>
        /// Id of the user linked to custom setting.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Name of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Value of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
