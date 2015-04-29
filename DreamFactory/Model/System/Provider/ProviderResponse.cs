// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.Provider
{
    using global::System;

    /// <summary>
    /// ProviderResponse.
    /// </summary>
    public class ProviderResponse
    {
        /// <summary>
        /// Identifier of this provider.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// The name of this provider
        /// </summary>
        public string provider_name { get; set; }

        /// <summary>
        /// The "api_name" or endpoint of this provider.
        /// </summary>
        public string api_name { get; set; }

        /// <summary>
        /// If true, this provider is active and available for use.
        /// </summary>
        public bool? is_active { get; set; }

        /// <summary>
        /// If true, this provider can be used to authenticate users.
        /// </summary>
        public bool? is_login_provider { get; set; }

        /// <summary>
        /// If true, this provider is a system provider and cannot be changed.
        /// </summary>
        public bool? is_system { get; set; }

        /// <summary>
        /// The ID of the provider upon which this provider is based. This parameter is deprecated in favor of the new "provider_name" field.
        /// </summary>
        public int? base_provider_id { get; set; }

        /// <summary>
        /// An array of configuration settings for this provider.
        /// </summary>
        public ProviderConfigSettings config_text { get; set; }

        /// <summary>
        /// Date this record was created.
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// User Id of who created this record.
        /// </summary>
        public int? created_by_id { get; set; }

        /// <summary>
        /// Date this record was last modified.
        /// </summary>
        public DateTime? last_modified_date { get; set; }

        /// <summary>
        /// User Id of who last modified this record.
        /// </summary>
        public int? last_modified_by_id { get; set; }
    }
}