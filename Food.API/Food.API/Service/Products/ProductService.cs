using Food.API.DTO.Products;
using Food.API.Infra;
using Food.API.Models.Products;
using System.Text.Json;

namespace Food.API.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }


        public async Task<int> Create(AddProductDTO dto)
        {
            

            var entity = _mapper.MapNew(dto);

            var fakeStoreDTO = _mapper.MapFakeStoreDTO(entity);

            var fakeStoreId = await FakeStoreClient.AddNewProductToFakeStore(fakeStoreDTO);

            entity.FakeStoreId = fakeStoreId;

            await _productRepository.Create(entity);

            return entity.Id;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public PaginatedReturn GetAll(string? barCode, string? name, int page)
        {
            return _productRepository.GetAll(barCode, name, page);
        }

        public Product? GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public async Task Update(int id, EditProductDTO product)
        {
            var productExists = _productRepository.GetById(id) ?? throw new Exception("Product not Found");

            _mapper.MapEdit(product, productExists);

            var fakeStoreDTO = _mapper.MapFakeStoreDTO(productExists);

            await FakeStoreClient.UpdateProductInTheFakeStore(fakeStoreDTO);

            await _productRepository.Update(productExists);
        }
    }
}
