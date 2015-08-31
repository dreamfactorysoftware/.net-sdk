namespace DreamFactory.Model.System.Script
{
    using DreamFactory.Model.System.Event;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// ScriptTypeResponse.
    /// </summary>
    public class ScriptTypeResponse
    {
        /// <summary>
        /// Name of this script type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Class name for this script type.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Label for this script type.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Description for this script type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicator whether this script type is sandboxed or not.
        /// </summary>
        public bool? Sandboxed { get; set; }

        /// <summary>
        /// Created date for this script type.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Last modified date for this script type.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Event scripts with this script type.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.ScriptType.EventScripts)]
        public List<RelatedEventScript> EventScripts { get; set; }

        /// <summary>
        /// Users linked to this scrip type via event scripts.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.ScriptType.UsersInEventScripts)]
        public List<RelatedUser> UsersInEventScripts { get; set; }

        /// <summary>
        /// Script config for this script.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.ScriptType.ScriptConfig)]
        public object ScriptConfig { get; set; }

        /// <summary>
        /// Services linked to this script type via script config.
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = RelatedResources.ScriptType.ServicesInScriptConfig)]
        public List<RelatedService> ServicesInScriptConfig { get; set; }
    }
}
