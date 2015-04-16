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
        /// List the container's contents, including properties.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="flags">Combination of <see cref="ListingFlags"/> values.</param>
        /// <returns><see cref="ContainerResponse"/>.</returns>
        Task<ContainerResponse> GetContainerAsync(string container, ListingFlags flags);

        /// <summary>
        /// Create container and/or add contents.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="containerData"><see cref="ContainerRequest"/> instance.</param>
        /// <param name="checkExists">If true, the request fails when the file or folder to create already exists.</param>
        /// <returns><see cref="ContainerResponse"/>.</returns>
        Task<ContainerResponse> CreateContainerAsync(string container, ContainerRequest containerData, bool checkExists = true);

        /// <summary>
        /// Rename the container's name.
        /// </summary>
        /// <param name="container">Current container's name.</param>
        /// <param name="newContainer">New content_only.</param>
        Task RenameContainerAsync(string container, string newContainer);

        /// <summary>
        /// Delete one container and/or its contents.
        /// </summary>
        /// <param name="container">The name of the container you want to delete from.</param>
        /// <param name="force">Set to true to force delete on a non-empty container.</param>
        /// <param name="contentOnly">Set to true to only delete the contents of the container.</param>
        /// <returns><see cref="ContainerResponse"/>.</returns>
        Task<ContainerResponse> DeleteContainerAsync(string container, bool force = false, bool contentOnly = false);

        /// <summary>
        /// List the container's contents, including properties.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="path">The path of the folder you want to retrieve. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="flags">Combination of <see cref="ListingFlags"/> values.</param>
        /// <returns><see cref="FolderResponse"/>.</returns>
        Task<FolderResponse> GetFolderAsync(string container, string path, ListingFlags flags);

        /// <summary>
        /// Create folder and/or add contents.
        /// </summary>
        /// <param name="container">Container's name.</param>
        /// <param name="path">The path of the folder you want to create. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="folderData"><see cref="FolderRequest"/> instance.</param>
        /// <param name="checkExists">If true, the request fails when the file or folder to create already exists.</param>
        /// <returns><see cref="FolderResponse"/>.</returns>
        Task<FolderResponse> CreateFolderAsync(string container, string path, FolderRequest folderData, bool checkExists = true);

        /// <summary>
        /// Rename the folder's name.
        /// </summary>
        /// <param name="container">Current container's name.</param>
        /// <param name="path">The path of the folder you want to rename. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="newFolder">New folder's name.</param>
        Task RenameFolderAsync(string container, string path, string newFolder);

        /// <summary>
        /// Delete one folder and/or its contents.
        /// </summary>
        /// <param name="container">The name of the folder you want to delete from.</param>
        /// <param name="path">The path of the folder you want to delete. This can be a sub-folder, with each level separated by a '/'.</param>
        /// <param name="force">Set to true to force delete on a non-empty folder.</param>
        /// <param name="contentOnly">Set to true to only delete the contents of the folder.</param>
        /// <returns><see cref="FolderResponse"/>.</returns>
        Task<FolderResponse> DeleteFolderAsync(string container, string path, bool force = false, bool contentOnly = false);

        /// <summary>
        /// Get the file contents.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <returns>File contents.</returns>
        Task<string> GetFileAsync(string container, string filepath);

        /// <summary>
        /// Create a new file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="content">File contents.</param>
        /// <param name="checkExists">If true, the call fails when the file to create already exists.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> CreateFileAsync(string container, string filepath, string content, bool checkExists = true);

        /// <summary>
        /// Update contents of the file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to update.</param>
        /// <param name="contents">New file contents.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> ReplaceFileAsync(string container, string filepath, string contents);

        /// <summary>
        /// Rename the file.
        /// </summary>
        /// <param name="container">Current container's name.</param>
        /// <param name="filepath">The path of the file you want to rename.</param>
        /// <param name="newFile">New file's name.</param>
        /// <param name="newType">New file's contents type.</param>
        Task RenameFileAsync(string container, string filepath, string newFile, string newType);

        /// <summary>
        /// Delete one file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to delete.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> DeleteFileAsync(string container, string filepath);
    }
}
