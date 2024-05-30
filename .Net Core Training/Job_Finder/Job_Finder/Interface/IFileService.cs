namespace Job_Finder.Interface
{
    /// <summary>
    /// Interface for file operations.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Uploads a file to the specified file path.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="filePath">The destination file path.</param>
        void UploadFile(IFormFile file, string filePath);

        /// <summary>
        /// Downloads a file from the specified file path.
        /// </summary>
        /// <param name="filePath">The file path of the file to download.</param>
        /// <returns>A stream containing the downloaded file content.</returns>
        Stream DownloadFile(string filePath);
    }
}
