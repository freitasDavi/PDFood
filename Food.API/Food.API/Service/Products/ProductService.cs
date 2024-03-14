using Food.API.Models.Products;

namespace Food.API.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public int Create(Product product)
        {
            return _productRepository.Create(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public List<Product> GetAll(string? barCode, string? name, int page)
        {
            return _productRepository.GetAll(barCode, name, page);
        }

        public Product? GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Update(int id, Product product)
        {
            var productExists = _productRepository.GetById(id) ?? throw new Exception("Product not Found");
            
            _productRepository.Update(product);
        }
    }
}
