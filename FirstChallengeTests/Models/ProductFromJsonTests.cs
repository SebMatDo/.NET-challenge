using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstChallengue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace FirstChallengue.Tests
{
    [TestClass()]
    public class ProductFromJsonTests
    {

        [TestMethod()]
        public void ValidateProductTypeTestOnValid()
        {
            var productTest = new ProductFromJson();
            productTest.ProductType = "Bienes";
            bool result = productTest.ValidateProductType();
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void ValidateProductStatusTestOnValid()
        {
            var productTest = new ProductFromJson();
            productTest.ProductStatus = "activo";
            bool result = productTest.ValidateProductStatus();
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void ValidateValueTestOnValid()
        {
            var productTest = new ProductFromJson();
            productTest.Value = (decimal) 200000.234;
            bool result = productTest.ValidateValue();
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void ValidateProductTypeTestOnInvalid()
        {
            var productTest = new ProductFromJson();
            productTest.ProductType = "Inversiones";
            bool result = productTest.ValidateProductType();
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void ValidateProductStatusTestOnInvalid()
        {
            var productTest = new ProductFromJson();
            productTest.ProductStatus = "deshabilitado";
            bool result = productTest.ValidateProductStatus();
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void ValidateValueTestOnInvalid()
        {
            var productTest = new ProductFromJson();
            productTest.Value = 0;
            bool result = productTest.ValidateValue();
            Assert.AreEqual(false, result);
        }
    }
}