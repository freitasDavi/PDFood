using Food.API.Models.Products;

namespace Food.API.Service.Products
{
    public interface IProductService
    {
        List<Product> GetAll(string? barCode, string? name, int page);
        Product? GetById(int id);
        Task Update(int id, Product product);
        Task<int> Create(Product product);
        void Delete(int id);
    }
}
