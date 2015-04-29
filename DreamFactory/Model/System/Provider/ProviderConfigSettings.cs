// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.Provider
{
    using global::System.Collections.Generic;

    /// <summary>
    /// ProviderConfigSettings.
    /// </summary>
    public class ProviderConfigSettings
    {
        /// <summary>
        /// Array of provider configuration settings.
        /// </summary>
        public List<KeyValuePair<string, string>> config_text { get; set; }
    }
}