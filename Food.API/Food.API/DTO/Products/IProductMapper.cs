using Food.API.Models.Products;

namespace Food.API.DTO.Products
{
    public interface IProductMapper
    {
        Product MapNew(AddProductDTO dto);
        void MapEdit(EditProductDTO dto, Product entity);
        FakesStoreProductDTO MapFakeStoreDTO(Product product);
    }
}
