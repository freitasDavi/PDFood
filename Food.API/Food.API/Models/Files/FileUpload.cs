using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food.API.Models.Files
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty; 
        public byte[]? Image { get; set; }
    }
}
