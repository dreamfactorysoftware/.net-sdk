// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// FileResponse.
    /// </summary>
    public class FileResponseModel : IModel
    {
        /// <summary>
        /// File info.
        /// </summary>
        public List<FileResponse> file { get; set; }
    }

    /// <summary>
    /// File info.
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
        /// An array of name-value pairs.
        /// </summary>
        public List<string> metadata { get; set; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        public string content_length { get; set; }

        /// <summary>
        /// File content (when requested).
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// A GMT date timestamp of when the file was last modified.
        /// </summary>
        public string last_modified { get; set; }
    }
}
