namespace DreamFactory.Model.File
{
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// FolderResponse.
    /// </summary>
    public class FolderResponse
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
        /// A GMT date timestamp of when the folder was last modified.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// An array of contained sub-folders.
        /// </summary>
        public List<FolderResponse> Folder { get; set; }

        /// <summary>
        /// An array of contained files.
        /// </summary>
        public List<FileResponse> File { get; set; }
    }
}
