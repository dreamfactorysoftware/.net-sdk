namespace DreamFactory.Model.System.Event
{
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.User;
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// EventScriptResponse.
    /// </summary>
    public class EventScriptResponse
    {
        /// <summary>
        /// Name for this event script
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of this event script.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicator whether this event script is active.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Indicator whether this event script affects process.
        /// </summary>
        public bool? AffectsProcess { get; set; }

        /// <summary>
        /// Content of this event script.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Config for this event script.
        /// </summary>
        public string Config { get; set; }

        /// <summary>
        /// Date this event script was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this event script was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User that created this event script.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.EventScript.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// User that last modified this event script.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.EventScript.UserLastModified)]
        public RelatedUser UserLastModified { get; set; }

        /// <summary>
        /// Script type of this event script.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.EventScript.ScriptType)]
        public RelatedScriptType ScriptType { get; set; }
    }
}
