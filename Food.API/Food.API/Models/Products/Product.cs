using System.ComponentModel.DataAnnotations;

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
        public byte[]? Image { get; set; }
        public int FakeStoreId { get; set; }

    }
}
