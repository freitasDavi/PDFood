using Food.API.Models.Products;

namespace Food.API.DTO.Products
{
    public class PaginatedReturn
    {
        public List<Product> Products { get; set; }
        public int PageIndex { get; set; }
        public int Total { get; set; }
    }
}
