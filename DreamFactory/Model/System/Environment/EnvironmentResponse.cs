// ReSharper disable InconsistentNaming
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
        public ServerSection server { get; set; }

        /// <summary>
        /// release.
        /// </summary>
        public ReleaseSection release { get; set; }

        /// <summary>
        /// platform.
        /// </summary>
        public PlatformSection platform { get; set; }

        /// <summary>
        /// php_info.
        /// </summary>
        public PhpInfoSection php_info { get; set; }
    }
}
