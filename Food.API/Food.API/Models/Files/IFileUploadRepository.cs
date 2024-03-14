namespace Food.API.Models.Files
{
    public interface IFileUploadRepository
    {
        Task<string> SaveFile(FileUpload file);
    }
}
