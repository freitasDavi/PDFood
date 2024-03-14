namespace Food.API.Models.Products
{
    public interface IProductRepository
    {
        List<Product> GetAll(string? barCode, string? name, int page);
        Product? GetById(int id);
        void Update(Product product);
        int Create(Product product);
        void Delete(int id);
    }
}
