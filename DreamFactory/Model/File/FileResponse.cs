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
        public string name { get; set; }

        /// <summary>
        /// Full path of the file, from the service including container.
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// The media type of the content of the file.
        /// </summary>
        public string content_type { get; set; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        public string content_length { get; set; }

        /// <summary>
        /// A GMT date timestamp of when the file was last modified.
        /// </summary>
        public DateTime? last_modified { get; set; }
    }
}
