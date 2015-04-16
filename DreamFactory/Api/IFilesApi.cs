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
        /// <param name="containers">List of container names to create.</param>
        /// <param name="checkExists">If true, the call fails when the container to create already exists.</param>
        /// <returns></returns>
        Task CreateContainersAsync(IEnumerable<string> containers, bool checkExists = true);

        /// <summary>
        /// Delete one or more containers.
        /// </summary>
        /// <param name="containers">List of containers to delete.</param>
        Task DeleteContainersAsync(IEnumerable<string> containers);

        /// <summary>
        /// List the container's content, including properties.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="mode">Combination of <see cref="ListFiles"/> values.</param>
        /// <returns><see cref="ContainerResponse"/>.</returns>
        Task<ContainerResponse> GetContainerAsync(string container, ListFiles mode);

        /// <summary>
        /// Create container and/or add content.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="containerData"><see cref="ContainerRequest"/> instance.</param>
        /// <param name="checkExists">If true, the request fails when the file or folder to create already exists.</param>
        /// <returns><see cref="ContainerResponse"/>.</returns>
        Task<ContainerResponse> CreateContainerAsync(string container, ContainerRequest containerData, bool checkExists = true);

        /// <summary>
        /// Renames the container's name.
        /// </summary>
        /// <param name="container">Current container's name.</param>
        /// <param name="newContainer">New content_only.</param>
        Task RenameContainerAsync(string container, string newContainer);

        /// <summary>
        /// Delete one container and/or its contents.
        /// </summary>
        /// <param name="container">The name of the container you want to delete from.</param>
        /// <param name="force">Set to true to force delete on a non-empty container.</param>
        /// <param name="contentOnly">Set to true to only delete the content of the container.</param>
        /// <returns><see cref="ContainerResponse"/>.</returns>
        Task<ContainerResponse> DeleteContainerAsync(string container, bool force = false, bool contentOnly = false);

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
