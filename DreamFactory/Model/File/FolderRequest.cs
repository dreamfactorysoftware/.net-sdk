namespace DreamFactory.Model.File
{
    using global::System.Collections.Generic;

    /// <summary>
    /// FolderRequest.
    /// </summary>
    public class FolderRequest
    {
        /// <summary>
        /// Gets Identifier/Name for the folder, localized to requested resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full path of the folder, from the service including container.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// An array of sub-folders to create.
        /// </summary>
        public List<FolderRequest> Folder { get; set; }

        /// <summary>
        /// An array of files to create.
        /// </summary>
        public List<FileRequest> File { get; set; }
    }
}
