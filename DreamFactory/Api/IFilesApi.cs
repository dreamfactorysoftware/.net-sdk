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
        /// List all role accessible resources.
        /// </summary>
        /// <returns>List of accessible resource names for the user's role.</returns>
        Task<IEnumerable<string>> GetAccessComponentsAsync();

        /// <summary>
        /// List all containers with properties.
        /// </summary>
        /// <returns>ContainerInfo objects for all containers.</returns>
        Task<IEnumerable<ContainerInfo>> GetContainersAsync();

        /// <summary>
        /// Create one or more containers.
        /// </summary>
        /// <param name="checkExists">If true, the call fails when the container to create already exists.</param>
        /// <param name="containers">List of container names to create.</param>
        /// <returns></returns>
        Task CreateContainersAsync(bool checkExists, params string[] containers);

        /// <summary>
        /// Delete one or more containers.
        /// </summary>
        /// <remarks>
        /// Only empty containers can be deleted.
        /// </remarks>
        /// <param name="containers">List of containers to delete.</param>
        Task DeleteContainersAsync(params string[] containers);

        /// <summary>
        /// List the container's contents, including properties.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="flags">Combination of <see cref="ListingFlags"/> values.</param>
        /// <returns><see cref="ContainerResponse"/>.</returns>
        Task<ContainerResponse> GetContainerAsync(string container, ListingFlags flags);

        /// <summary>
        /// Download the container files as ZIP archive.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <returns>ZIP archive bytes.</returns>
        Task<byte[]> DownloadContainerAsync(string container);

        /// <summary>
        /// Create container and/or add contents from a ZIP archive located at <paramref name="url"/>.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="url">ZIP file location (URL).</param>
        /// <param name="clean">Clean the current folder before extracting files and folders.</param>
        Task UploadContainerAsync(string container, string url, bool clean);

        /// <summary>
        /// Delete one container and/or its contents.
        /// </summary>
        /// <param name="container">The name of the container you want to delete.</param>
        /// <param name="force">Set to true to force delete on a non-empty container.</param>
        Task DeleteContainerAsync(string container, bool force = false);

        /// <summary>
        /// List the container's contents, including properties.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="path">The path of the folder you want to retrieve. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="flags">Combination of <see cref="ListingFlags"/> values.</param>
        /// <returns><see cref="FolderResponse"/>.</returns>
        Task<FolderResponse> GetFolderAsync(string container, string path, ListingFlags flags);

        /// <summary>
        /// Download the folder files as ZIP archive.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="path">The path of the folder you want to retrieve. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <returns>ZIP archive bytes.</returns>
        Task<byte[]> DownloadFolderAsync(string container, string path);

        /// <summary>
        /// Create folder and/or add contents.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="path">The path of the folder you want to create. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="checkExists">If true, the request fails when the file or folder to create already exists.</param>
        /// <returns><see cref="FolderResponse"/>.</returns>
        Task CreateFolderAsync(string container, string path, bool checkExists = true);

        /// <summary>
        /// Create folder and/or add contents from a ZIP archive located at <paramref name="url"/>.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="path">The path of the folder you want to create. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="url">ZIP file location (URL).</param>
        /// <param name="clean">Clean the current folder before extracting files and folders.</param>
        Task UploadFolderAsync(string container, string path, string url, bool clean);

        /// <summary>
        /// Delete one folder and/or its contents.
        /// </summary>
        /// <param name="container">The name of the folder you want to delete from.</param>
        /// <param name="path">The path of the folder you want to delete. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="force">Set to true to force delete on a non-empty folder.</param>
        Task DeleteFolderAsync(string container, string path, bool force = false);

        /// <summary>
        /// Get the file contents as text (UTF8).
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <returns>File contents.</returns>
        Task<string> GetTextFileAsync(string container, string filepath);

        /// <summary>
        /// Get the file contents as octet stream.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <returns>File contents.</returns>
        Task<byte[]> GetBinaryFileAsync(string container, string filepath);

        /// <summary>
        /// Create a new text file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="content">File contents.</param>
        /// <param name="checkExists">If true, the call fails when the file to create already exists.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> CreateFileAsync(string container, string filepath, string content, bool checkExists = true);

        /// <summary>
        /// Create a new binary file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="contents">File contents.</param>
        /// <param name="checkExists">If true, the call fails when the file to create already exists.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> CreateFileAsync(string container, string filepath, byte[] contents, bool checkExists = true);

        /// <summary>
        /// Update contents of the text file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to update.</param>
        /// <param name="contents">New file contents (text).</param>
        Task ReplaceFileContentsAsync(string container, string filepath, string contents);

        /// <summary>
        /// Update contents of the binary file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to update.</param>
        /// <param name="contents">New file contents (bytes).</param>
        Task ReplaceFileContentsAsync(string container, string filepath, byte[] contents);

        /// <summary>
        /// Delete one file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to delete.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> DeleteFileAsync(string container, string filepath);
    }
}
