using Food.API.DTO.Products;
using Food.API.Models.Files;
using Microsoft.AspNetCore.Mvc;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadRepository _repository;

        public FileUploadController(IFileUploadRepository fileUploadRepository)
        {
            _repository = fileUploadRepository;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Upload(
            [FromForm] IFormFile file
            )
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Image not found");
                }

                byte[] imageData;

                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    imageData = ms.ToArray();

                }

                string imreBase64Data = Convert.ToBase64String(imageData);
                string imageUrl = string.Format("data:image/png;base64,{0}", imreBase64Data);

                await _repository.SaveFile(new FileUpload
                {
                    Name = file.Name,
                    Image = imageData,
                    Url = imageUrl
                });

                return Ok(imageUrl);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
