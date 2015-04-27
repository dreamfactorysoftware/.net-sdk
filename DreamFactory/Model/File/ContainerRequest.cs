// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.File
{
    using global::System.Collections.Generic;

    /// <summary>
    /// ContainerRequest.
    /// </summary>
    public class ContainerRequest
    {
        /// <summary>
        /// Gets Identifier/Name for the container, localized to requested resource.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Same as name for the container, for consistency.
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// An array of folders to create.
        /// </summary>
        public List<FolderRequest> folder { get; set; }

        /// <summary>
        /// An array of files to create.
        /// </summary>
        public List<FileRequest> file { get; set; }
    }
}
