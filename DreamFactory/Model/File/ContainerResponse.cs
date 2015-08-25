namespace DreamFactory.Model.File
{
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// ContainerResponse.
    /// </summary>
    public class ContainerResponse
    {
        /// <summary>
        /// Gets Identifier/Name for the container, localized to requested resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Same as name for the container, for consistency.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// A GMT date timestamp of when the container was last modified.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// An array of contained folders.
        /// </summary>
        public List<FolderResponse> Folder { get; set; }

        /// <summary>
        /// An array of contained files.
        /// </summary>
        public List<FileResponse> File { get; set; }
    }
}
