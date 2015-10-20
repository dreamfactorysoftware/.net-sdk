namespace DreamFactory.Model.System.Environment
{
    using DreamFactory.Model.System.App;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// EnvironmentResponse.
    /// </summary>
    public class EnvironmentResponse
    {

        /// <summary>
        /// Platform info.
        /// </summary>
        [JsonProperty(PropertyName = "platform")]
        public PlatformSection Platform { get; set; }

        /// <summary>
        /// Authentication metadata.
        /// </summary>
        [JsonProperty(PropertyName = "authentication")]
        public object Authentication { get; set; }

        /// <summary>
        /// Server metadata.
        /// </summary>
        [JsonProperty(PropertyName = "server")]
        public object Server { get; set; }

        /// <summary>
        /// Config metadata.
        /// </summary>
        [JsonProperty(PropertyName = "config")]
        public object Config { get; set; }

        /// <summary>
        /// Related app groups.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Environment.AppsInAppGroups)]
        public List<RelatedApp> AppsInAppGroups { get; set; }

        /// <summary>
        /// Unrelated app groups.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Environment.AppsNotInAppGroups)]
        public List<RelatedApp> AppsNotInAppGroups { get; set; }
    }
}
