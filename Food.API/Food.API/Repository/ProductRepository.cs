using Food.API.DTO.Products;
using Food.API.Models.Products;

namespace Food.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<int> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public void Delete(int id)
        {
            var prod = GetById(id) ?? throw new Exception("Product not found!");

            _context.Products.Remove(prod);
            _context.SaveChanges();
        }

        public PaginatedReturn GetAll(string? barCode, string? name, int page)
        {
            var LIMIT = 10;
            var query = _context.Products.AsQueryable();

            if (barCode != null)
            {
                query = query.Where(p => p.BarCode.Contains(barCode));
            }

            if (name != null)
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            var totalCount = query.Count();

            return new PaginatedReturn {
                Total = totalCount,
                Products = query.Skip(page * LIMIT).Take(LIMIT).ToList(),
                PageIndex = page
            };
        }

        public Product? GetById(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public async Task Update(Product product)
        {
            var prod = GetById(product.Id)!;

            prod.Price = product.Price;
            prod.Name = product.Name;
            prod.ImageUrl = product.ImageUrl;

            await _context.SaveChangesAsync();
        }
    }
}
