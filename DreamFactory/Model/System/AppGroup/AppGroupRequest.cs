namespace DreamFactory.Model.System.AppGroup
{
    using Newtonsoft.Json;

    /// <summary>
    /// AppGroupResponse.
    /// </summary>
    public class AppGroupRequest : IRecord
    {
        /// <summary>
        /// Identifier of this application group.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this application group.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of this application group.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}