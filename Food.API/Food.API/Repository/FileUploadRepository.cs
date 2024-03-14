using Food.API.Models.Files;
using Food.API.Models.Products;

namespace Food.API.Repository
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly AppDbContext _context;

        public FileUploadRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<string> SaveFile(FileUpload file)
        {
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();

            return file.Name;
        }
    }
}
