namespace DreamFactory.Model.File
{
    /// <summary>
    /// FileRequest.
    /// </summary>
    public class FileRequest
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
    }
}
