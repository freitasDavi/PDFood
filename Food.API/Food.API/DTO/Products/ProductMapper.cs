using Food.API.Models.Products;

namespace Food.API.DTO.Products
{
    public class ProductMapper : IProductMapper
    {
        public void MapEdit(EditProductDTO dto, Product entity)
        {
            entity.Price = dto.Price;
            entity.BarCode = dto.BarCode;
            entity.Name = dto.Name;
            entity.ImageUrl = dto.ImageUrl; 
        }

        public Product MapNew(AddProductDTO dto)
        {
            return new Product
            {
                Price = dto.Price,
                BarCode = dto.BarCode,
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
            };
        }

        public FakesStoreProductDTO MapFakeStoreDTO(Product product)
        {
            return new FakesStoreProductDTO
            {
                Id = product.FakeStoreId,
                Name = product.Name,
                Image = product.ImageUrl,
                Price = product.Price,
                Description = product.Name,
                Category = "Geral"
            };
        }
    }
}
