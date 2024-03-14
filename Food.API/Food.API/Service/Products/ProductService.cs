using Food.API.DTO;
using Food.API.Infra;
using Food.API.Models.Products;
using System.Text.Json;

namespace Food.API.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<int> Create(Product product)
        {
            var dto = MapFakeStoreDTO(product);

            var fakeStoreId = await FakeStoreClient.AddNewProductToFakeStore(dto);

            product.FakeStoreId = fakeStoreId;

            await _productRepository.Create(product);

            return product.Id;
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

        public async Task Update(int id, Product product)
        {
            var productExists = _productRepository.GetById(id) ?? throw new Exception("Product not Found");

            var fakeStoreDTO = MapFakeStoreDTO(product);

            await FakeStoreClient.UpdateProductInTheFakeStore(fakeStoreDTO);

            await _productRepository.Update(product);
        }

        

        private FakesStoreProductDTO MapFakeStoreDTO (Product product)
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
