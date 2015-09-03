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
        public PlatformSection Platform { get; set; }

        /// <summary>
        /// Authentication metadata.
        /// </summary>
        public object Authentication { get; set; }

        /// <summary>
        /// Server metadata.
        /// </summary>
        public object Server { get; set; }

        /// <summary>
        /// Config metadata.
        /// </summary>
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
