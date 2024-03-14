using Food.API.DTO.Products;

namespace Food.API.Models.Products
{
    public interface IProductRepository
    {
        PaginatedReturn GetAll(string? barCode, string? name, int page);
        Product? GetById(int id);
        Task Update(Product product);
        Task<int> Create(Product product);
        void Delete(int id);
    }
}
