using Job_Finder.Interface;

namespace Job_Finder.BusinessLogic
{
    public class BLFileServiceHandler : IFileService
    {
        public Stream DownloadFile(string filePath)
        {
            return new FileStream(filePath, FileMode.Open);
        }

        public void UploadFile(IFormFile file, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
