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
        public bool? is_hosted { get; set; }

        /// <summary>
        /// is_private.
        /// </summary>
        public bool? is_private { get; set; }

        /// <summary>
        /// dsp_version_current.
        /// </summary>
        public string dsp_version_current { get; set; }

        /// <summary>
        /// dsp_version_latest.
        /// </summary>
        public string dsp_version_latest { get; set; }

        /// <summary>
        /// upgrade_available.
        /// </summary>
        public bool? upgrade_available { get; set; }
    }
}