namespace DreamFactory.Model.File
{
    using global::System;

    /// <summary>
    /// FileResponse.
    /// </summary>
    public class FileResponse
    {
        /// <summary>
        /// Gets Identifier/Name for the file, localized to requested resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full path of the file, from the service including container.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The media type of the content of the file.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        public string ContentLength { get; set; }

        /// <summary>
        /// A GMT date timestamp of when the file was last modified.
        /// </summary>
        public DateTime? LastModified { get; set; }
    }
}
