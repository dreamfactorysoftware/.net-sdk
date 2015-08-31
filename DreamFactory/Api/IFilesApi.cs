namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model.File;

    /// <summary>
    /// Represents /files API.
    /// </summary>
    public interface IFilesApi
    {
        /// <summary>
        /// List all resources.
        /// </summary>
        /// <param name="flags">Combination of <see cref="ListingFlags"/> values.</param>
        /// <returns><see cref="StorageResource"/>object for all resources.</returns>
        Task<IEnumerable<StorageResource>> GetResourcesAsync(ListingFlags flags);

        /// <summary>
        /// List all resource names.
        /// </summary>
        /// <returns>All resource names.</returns>        
        Task<IEnumerable<string>> GetResourceNamesAsync();

        /// <summary>
        /// List the folders's contents, including properties.
        /// </summary>
        /// <param name="path">The path of the folder you want to retrieve. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="flags">Combination of <see cref="ListingFlags"/> values.</param>
        /// <returns><see cref="FolderResponse"/>.</returns>
        Task<FolderResponse> GetFolderAsync(string path, ListingFlags flags);

        /// <summary>
        /// Download the folder files as ZIP archive.
        /// </summary>
        /// <param name="path">The path of the folder you want to retrieve. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <returns>ZIP archive bytes.</returns>
        Task<byte[]> DownloadFolderAsync(string path);

        /// <summary>
        /// Create folder and/or add contents.
        /// </summary>
        /// <param name="path">The path of the folder you want to create. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="checkExists">If true, the request fails when the file or folder to create already exists.</param>
        /// <returns><see cref="FolderResponse"/>.</returns>
        Task<FolderResponse> CreateFolderAsync(string path, bool checkExists = true);

        /// <summary>
        /// Create folder and/or add contents from a ZIP archive located at <paramref name="url"/>.
        /// </summary>
        /// <param name="path">The path of the folder you want to create. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="url">ZIP file location (URL).</param>
        /// <param name="clean">Clean the current folder before extracting files and folders.</param>
        Task<FolderResponse> UploadFolderAsync(string path, string url, bool clean);

        /// <summary>
        /// Delete one folder and/or its contents.
        /// </summary>
        /// <param name="path">The path of the folder you want to delete. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="force">Set to true to force delete on a non-empty folder.</param>
        Task<FolderResponse> DeleteFolderAsync(string path, bool force = false);

        /// <summary>
        /// Get the file contents as text (UTF8).
        /// </summary>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <returns>File contents.</returns>
        Task<string> GetTextFileAsync(string filepath);

        /// <summary>
        /// Get the file contents as octet stream.
        /// </summary>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <returns>File contents.</returns>
        Task<byte[]> GetBinaryFileAsync(string filepath);

        /// <summary>
        /// Create a new text file.
        /// </summary>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="content">File contents.</param>
        /// <param name="checkExists">If true, the call fails when the file to create already exists.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> CreateFileAsync(string filepath, string content, bool checkExists = true);

        /// <summary>
        /// Create a new binary file.
        /// </summary>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="contents">File contents.</param>
        /// <param name="checkExists">If true, the call fails when the file to create already exists.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> CreateFileAsync(string filepath, byte[] contents, bool checkExists = true);

        /// <summary>
        /// Update contents of the text file.
        /// </summary>
        /// <param name="filepath">Path and name of the file to update.</param>
        /// <param name="contents">New file contents (text).</param>
        Task<FileResponse> ReplaceFileContentsAsync(string filepath, string contents);

        /// <summary>
        /// Update contents of the binary file.
        /// </summary>
        /// <param name="filepath">Path and name of the file to update.</param>
        /// <param name="contents">New file contents (bytes).</param>
        Task<FileResponse> ReplaceFileContentsAsync(string filepath, byte[] contents);

        /// <summary>
        /// Delete one file.
        /// </summary>
        /// <param name="filepath">Path and name of the file to delete.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> DeleteFileAsync(string filepath);
    }
}
