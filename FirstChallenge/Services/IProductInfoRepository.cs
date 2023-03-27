using FirstChallengue.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstChallengue.Services
{
    //Interfaz que se encarga de definir los metodos que debe tener el servicio info product
    public interface IProductInfoRepository
    {
        public IQueryable<Product> GetProducts();
        public Product? GetProductById(long productId);
        public IQueryable<Product> GetProductsByDescription(string productDescription);
        public void AddProduct(Product product);
        public bool SaveDb();
        public void DeleteProduct(Product product);
        public void UpdateProduct(Product product);

    }
}
