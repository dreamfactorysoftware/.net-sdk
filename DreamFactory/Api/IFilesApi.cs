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
        /// <returns>List of containers.</returns>
        Task<IEnumerable<Container>> GetContainersAsync();

        /// <summary>
        /// Create one or more containers.
        /// </summary>
        /// <param name="containers">List of container names to create.</param>
        /// <param name="checkExists">If true, the call fails when the container to create already exists.</param>
        /// <returns></returns>
        Task CreateContainersAsync(IEnumerable<string> containers, bool checkExists = true);

        /// <summary>
        /// Delete one or more containers.
        /// </summary>
        /// <param name="names">List of containers to delete.</param>
        Task DeleteContainersAsync(IEnumerable<string> names);

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="content">File content.</param>
        /// <param name="checkExists">If true, the call fails when the file to create already exists.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> CreateFileAsync(string container, string filepath, string content, bool checkExists = true);

        /// <summary>
        /// Downloads the file content.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <returns>File content.</returns>
        Task<string> GetFileAsync(string container, string filepath);

        /// <summary>
        /// Deletes one file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to delete.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> DeleteFileAsync(string container, string filepath);
    }
}
