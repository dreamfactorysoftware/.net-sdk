namespace DreamFactory.Model.File
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// FolderRequest.
    /// </summary>
    public class FolderRequest
    {
        /// <summary>
        /// Gets Identifier/Name for the folder, localized to requested resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Full path of the folder, from the service including container.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// An array of sub-folders to create.
        /// </summary>
        [JsonProperty(PropertyName = "folder")]
        public List<FolderRequest> Folder { get; set; }

        /// <summary>
        /// An array of files to create.
        /// </summary>
        [JsonProperty(PropertyName = "file")]
        public List<FileRequest> File { get; set; }
    }
}
