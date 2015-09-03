namespace DreamFactory.Model.System.Environment
{
    /// <summary>
    /// PlatformSection.
    /// </summary>
    public class PlatformSection
    {
        /// <summary>
        /// is_hosted.
        /// </summary>
        public bool? IsHosted { get; set; }

        /// <summary>
        /// dsp_version_current.
        /// </summary>
        public string VersionCurrent { get; set; }

        /// <summary>
        /// dsp_version_latest.
        /// </summary>
        public string VersionLatest { get; set; }

        /// <summary>
        /// upgrade_available.
        /// </summary>
        public bool? UpgradeAvailable { get; set; }
    }
}		