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

        public int Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }

        public void Delete(int id)
        {
            var prod = GetById(id) ?? throw new Exception("Product not found!");

            _context.Products.Remove(prod);
            _context.SaveChanges();
        }

        public List<Product> GetAll(string? barCode, string? name, int page)
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

            return query.Skip(page * LIMIT).Take(LIMIT).ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Product product)
        {
            var prod = GetById(product.Id)!;

            prod.Price = product.Price;
            prod.Name = product.Name;
            prod.ImageUrl = product.ImageUrl;
            prod.Image = product.Image;

            _context.SaveChanges();
        }
    }
}
