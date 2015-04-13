namespace DreamFactory.Api
{
    using System.Threading.Tasks;
    using DreamFactory.Model;

    /// <summary>
    /// Represents /files API.
    /// </summary>
    public interface IFilesApi
    {
        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="content">File content.</param>
        /// <param name="checkExists">If true, the request fails when the file to create already exists.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> CreateFileAsync(string container, string filepath, string content, bool checkExists = true);

        /// <summary>
        /// Downloads the file content.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to create.</param>
        /// <param name="base64">Set to true to receive file content encoded as Base64.</param>
        /// <returns>File content.</returns>
        Task<string> GetFileAsync(string container, string filepath, bool base64 = false);

        /// <summary>
        /// Deletes one file.
        /// </summary>
        /// <param name="container">Name of the container where the file exists.</param>
        /// <param name="filepath">Path and name of the file to delete.</param>
        /// <returns>FileResponse object.</returns>
        Task<FileResponse> DeleteFileAsync(string container, string filepath);
    }
}
