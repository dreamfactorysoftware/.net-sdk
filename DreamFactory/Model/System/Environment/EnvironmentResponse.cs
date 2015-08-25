namespace DreamFactory.Model.System.Environment
{
    /// <summary>
    /// EnvironmentResponse.
    /// </summary>
    public class EnvironmentResponse
    {
        /// <summary>
        /// server.
        /// </summary>
        public ServerSection Server { get; set; }

        /// <summary>
        /// release.
        /// </summary>
        public ReleaseSection Release { get; set; }

        /// <summary>
        /// platform.
        /// </summary>
        public PlatformSection Platform { get; set; }

        /// <summary>
        /// php_info.
        /// </summary>
        public PhpInfoSection PhpInfo { get; set; }
    }
}
