using Food.API.DTO.Products;
using Food.API.Models.Products;

namespace Food.API.Service.Products
{
    public interface IProductService
    {
        PaginatedReturn GetAll(string? barCode, string? name, int page);
        Product? GetById(int id);
        Task Update(int id, EditProductDTO product);
        Task<int> Create(AddProductDTO product);
        void Delete(int id);
    }
}
