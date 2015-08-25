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
        /// is_private.
        /// </summary>
        public bool? IsPrivate { get; set; }

        /// <summary>
        /// dsp_version_current.
        /// </summary>
        public string DspVersionCurrent { get; set; }

        /// <summary>
        /// dsp_version_latest.
        /// </summary>
        public string DspVersionLatest { get; set; }

        /// <summary>
        /// upgrade_available.
        /// </summary>
        public bool? UpgradeAvailable { get; set; }
    }
}