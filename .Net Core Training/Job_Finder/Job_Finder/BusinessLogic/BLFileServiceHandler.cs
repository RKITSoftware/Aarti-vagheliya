using Job_Finder.Interface;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Provides file handling functionality.
    /// </summary>
    public class BLFileServiceHandler : IFileService
    {
        #region Public Method

        /// <summary>
        /// Downloads a file from the specified file path.
        /// </summary>
        /// <param name="filePath">The path of the file to download.</param>
        /// <returns>A stream representing the downloaded file.</returns>
        public Stream DownloadFile(string filePath)
        {
            return new FileStream(filePath, FileMode.Open);
        }

        /// <summary>
        /// Uploads a file to the specified file path.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="filePath">The path where the file will be uploaded.</param>
        public void UploadFile(IFormFile file, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        #endregion
    }
}
