using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food.API.Models.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        [JsonIgnore]
        public byte[]? Image { get; set; }
        [JsonIgnore]
        public int FakeStoreId { get; set; }

    }
}
