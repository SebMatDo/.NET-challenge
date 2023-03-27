using FirstChallengue.Models;
using FirstChallengue.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FirstChallengue.Controllers
{

    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductInfoRepository _productInfoRepository;
        public ProductController(IProductInfoRepository productInfoRepository)
        {
            _productInfoRepository = productInfoRepository ?? throw new ArgumentNullException(nameof(productInfoRepository));
        }

        [HttpGet("/getProducts")]
        public IActionResult getProducts()
        {
            // Se llama al servicio infoRepository
            // que nos devolverá un array con los datos de los productos
            var productsEntities = _productInfoRepository.GetProducts();

            // Se mapea esa información a objetos productToJson
            // (que pueden devolver string en vez de int en los enum)
            var productsList = new List<ProductToJson>();
            foreach (var product in productsEntities)
            {
                productsList.Add(new ProductToJson(product));
            }
            return Ok(productsList);
        }

        [HttpGet("getProductById/{searchProductId}")]
        public IActionResult getProductById(long searchProductId)
        {
            // Se llama al servicio infoRepository
            // que nos devolverá un array con los datos de los productos
            var product = _productInfoRepository.GetProductById(productId: searchProductId);
            if (product == null) return NotFound("No se encontró ningún producto que contenga ese Id");
            // Se mapea esa información a objetos product
            return Ok(new ProductToJson(product));
        }

        [HttpGet("searchProduct")]
        public IActionResult getProductsByDescription(string productDescription)
        {
            // Se llama al servicio infoRepository
            // que nos devolverá un array con los datos de los productos
            var productsEntities = _productInfoRepository.GetProductsByDescription(productDescription);

            // Se mapea esa información a objetos product
            var productsList = new List<ProductToJson>();
            foreach (var product in productsEntities)
            {
                productsList.Add(new ProductToJson(product));
            }
            if (productsList.Count != 0) return Ok(productsList);
            return NotFound("No se encontró ningún producto que contenga esa descripción");
        }


        [HttpPost("addProduct")]
        public IActionResult addProduct([FromBody] ProductFromJson product)
        {
            Product productToDb = new Product(product);
            _productInfoRepository.AddProduct(productToDb);
            _productInfoRepository.SaveDb();
            long idReturned = productToDb.Id;
            return CreatedAtAction(nameof(getProductById), new { searchProductId = idReturned }, new ProductToJson(productToDb));
        }

        [HttpDelete("deleteProduct/{productId}")]
        public IActionResult deleteProduct(long productId)
        {
            Product? productToRemove = _productInfoRepository.GetProductById(productId: productId);
            if (productToRemove == null) return NotFound("No se encontró ningún producto que contenga ese Id");
            _productInfoRepository.DeleteProduct(productToRemove);            
            _productInfoRepository.SaveDb();
            return Ok( new { message = "Se eliminó correctamente el siguiente producto" +
                "de la base de datos",
                product = new ProductToJson(productToRemove),
            }) ;

        }
        
        [HttpPut("updateProduct/{productId}")]
        public IActionResult updateProduct(long productId, [FromBody] JsonDocument patchDoc)
        {
            Product? productToPatch = _productInfoRepository.GetProductById(productId: productId);
            if (productToPatch == null) return NotFound("No se encontró ningún producto que contenga ese Id");

            // Make json deserialize non case sensitive
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            ProductFromJson? productFromPatch = patchDoc.Deserialize<ProductFromJson>(options);

            if (productFromPatch == null) return BadRequest("Error en la información del json");

            if (!productFromPatch.ValidateProductStatus()) return BadRequest("Por favor utilice un estado del producto valido (activo, inactivo)");
            if (!productFromPatch.ValidateProductType()) return BadRequest("Por favor utilice un tipo del producto valido (bienes, vehiculos, terrenos, apartamentos)");
            if (!productFromPatch.ValidateValue()) return BadRequest("Por favor utilice valores entre 1 y mil millones");
            productToPatch.updateInformation(productFromPatch);
            _productInfoRepository.UpdateProduct(productToPatch);
            _productInfoRepository.SaveDb();
            return Ok(new
            {
                message = "Se realizó una actualización exitosa del siguiente producto:",
                product = new ProductToJson(productToPatch),
            });
        }       
    }
}
