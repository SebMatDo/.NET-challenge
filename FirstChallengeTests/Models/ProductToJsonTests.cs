using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstChallengue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstChallengue.Models;
using System.Text.Json;

namespace FirstChallengue.Tests
{
    [TestClass()]
    public class ProductToJsonTests
    {
        [TestMethod()]
        public void ProductToJsonTestOnValid()
        {
            Product product = new Product
            {
                ProductStatus = false,
                ProductType = 0,
                Description = "Objeto nuevo",
                Id = 1,
                DateOfBuy = DateTime.Parse("2020-10-10"),
                Value = 10000,
                
            };
            ProductToJson expectedResult = new ProductToJson
            {
                ProductStatus = "Inactivo",
                ProductType = ProductType.Bienes.ToString(),
                Description = "Objeto nuevo",
                Id = 1,
                DateOfBuy = DateTime.Parse("2020-10-10"),
                Value = 10000,
            };

            ProductToJson result = new ProductToJson(product);
            
            Assert.AreEqual(JsonSerializer.Serialize( expectedResult), JsonSerializer.Serialize (result));
        }
        [TestMethod()]
        public void ProductToJsonTestOnInvalid()
        {
            Product product = new Product
            {
                ProductStatus = false,
                ProductType = 0,
                Description = "Objeto nuevo",
                Id = 1,
                DateOfBuy = DateTime.Parse("2020-10-10"),
                Value = 10000,

            };
            ProductToJson expectedResult = new ProductToJson
            {
                ProductStatus = "Activo",
                ProductType = ProductType.Bienes.ToString(),
                Description = "Objeto nuevo",
                Id = 1,
                DateOfBuy = DateTime.Parse("2020-10-10"),
                Value = 10000,
            };

            ProductToJson result = new ProductToJson(product);

            Assert.AreNotEqual(JsonSerializer.Serialize(expectedResult), JsonSerializer.Serialize(result));
        }
    }
}