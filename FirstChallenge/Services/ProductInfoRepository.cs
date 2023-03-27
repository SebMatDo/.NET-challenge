
using Microsoft.AspNetCore.Mvc;

namespace FirstChallengue.Services
{
    // Servicio que se encarga de las peticiones hacia la base de datos sobre informacion de productos
    public class ProductInfoRepository : IProductInfoRepository
    {
        private readonly FirstChallengeContext _context;
        public ProductInfoRepository(FirstChallengeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Product? GetProductById(long productId)
        {
            return _context.Products.Where(c => c.Id == productId).FirstOrDefault();
        }

        public IQueryable<Product> GetProductsByDescription(string productDescription)
        {
            return _context.Products.Where(c => c.Description.Contains(productDescription));
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);
        }

        public bool SaveDb()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
        }
    }
}
