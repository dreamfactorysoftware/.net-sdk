namespace DreamFactory.Model.System.Environment
{
    using Newtonsoft.Json;

    /// <summary>
    /// PlatformSection.
    /// </summary>
    public class PlatformSection
    {
        /// <summary>
        /// is_hosted.
        /// </summary>
        [JsonProperty(PropertyName = "is_hosted")]
        public bool? IsHosted { get; set; }

        /// <summary>
        /// dsp_version_current.
        /// </summary>
        [JsonProperty(PropertyName = "version_current")]
        public string VersionCurrent { get; set; }

        /// <summary>
        /// dsp_version_latest.
        /// </summary>
        [JsonProperty(PropertyName = "version_latest")]
        public string VersionLatest { get; set; }

        /// <summary>
        /// upgrade_available.
        /// </summary>
        [JsonProperty(PropertyName = "upgrade_available")]
        public bool? UpgradeAvailable { get; set; }

        /// <summary>
        /// Host name.
        /// </summary>
        [JsonProperty(PropertyName = "host")]
        public string Host { get; set; }
    }
}		