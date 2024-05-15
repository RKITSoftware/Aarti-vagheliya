namespace Job_Finder.Interface
{
    public interface IFileService
    {
        void UploadFile(IFormFile file, string filePath);
        Stream DownloadFile(string filePath);
    }
}
