namespace DreamFactory.Model.System.Service
{
    using global::System;

    /// <summary>
    /// RelatedServiceType.
    /// </summary>
    public class RelatedServiceType
    {
        /// <summary>
        /// Name of this script type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Class name of this script type.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Config handler of this script type.
        /// </summary>
        public string ConfigHandler { get; set; }

        /// <summary>
        /// Label for this script type.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Description for this script type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Group for this script type.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Indicator whether this service type is singleton.
        /// </summary>
        public bool? Singleton { get; set; }

        /// <summary>
        /// Date this script type was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this script type was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
