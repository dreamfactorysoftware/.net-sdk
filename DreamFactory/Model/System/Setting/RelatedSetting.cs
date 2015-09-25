namespace DreamFactory.Model.System.Setting
{
    using global::System;

    /// <summary>
    /// RelatedSetting.
    /// </summary>
    public class RelatedSetting
    {
        /// <summary>
        /// Id of this setting.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Name of this setting.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of this setting.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Id of the user that created this setting.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this setting.
        /// </summary>
        public int? ModifiedById { get; set; }

        /// <summary>
        /// Date this setting was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this setting was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
