namespace DreamFactory.Model.System.Script
{
    using global::System;

    /// <summary>
    /// RelatedScriptType.
    /// </summary>
    public class RelatedScriptType
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
        /// Label for this script type.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Description for this script type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicator whether this script type is sandboxed.
        /// </summary>
        public bool? Sandboxed { get; set; }

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
