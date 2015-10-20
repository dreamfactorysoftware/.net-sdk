namespace DreamFactory.Model.System.Role
{
    using Newtonsoft.Json;

    /// <summary>
    /// RoleResponse.
    /// </summary>
    public class RoleRequest : IRecord
    {
        /// <summary>
        /// Identifier of this role.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this role.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of this role.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Is this role active for use.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }
    }
}
