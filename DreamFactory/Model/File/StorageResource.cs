namespace DreamFactory.Model.File
{
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// A storage resource information.
    /// </summary>
    public class StorageResource
    {
        /// <summary>
        /// Identifier/Name for the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Path for the resource.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Date and time of last modification.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Resource content length.
        /// </summary>
        public int ContentLength { get; set; }

        /// <summary>
        /// Resource type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Resource content type.
        /// </summary>
        public string ContentType { get; set; }
    }
}
