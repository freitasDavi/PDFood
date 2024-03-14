namespace Food.API.DTO.Products
{
    public class AddProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
