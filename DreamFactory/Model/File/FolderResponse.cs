namespace DreamFactory.Model.File
{
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// FolderResponse.
    /// </summary>
    public class FolderResponse
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
        /// A GMT date timestamp of when the folder was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified")]
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// An array of contained sub-folders.
        /// </summary>
        [JsonProperty(PropertyName = "folder")]
        public List<FolderResponse> Folder { get; set; }

        /// <summary>
        /// An array of contained files.
        /// </summary>
        [JsonProperty(PropertyName = "file")]
        public List<FileResponse> File { get; set; }
    }
}
