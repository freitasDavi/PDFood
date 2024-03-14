using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food.API.Models.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        [JsonIgnore]
        public int FakeStoreId { get; set; }

    }
}
