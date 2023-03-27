using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstChallengue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstChallengue.Models.Tests
{
    [TestClass()]
    public class EnumProductTests
    {
        [TestMethod()]
        public void getProductTypeEnumFromStringTestLower()
        {
            string status = "bienes";
            EnumProduct enumProduct = new EnumProduct();
            var expected = ProductType.Bienes;
            var result = enumProduct.getProductTypeEnumFromString(status);
            Assert.AreEqual(expected,result);
        }

        [TestMethod()]
        public void getProductTypeEnumFromStringTestUpper()
        {
            string status = "BIENES";
            EnumProduct enumProduct = new EnumProduct();
            var expected = ProductType.Bienes;
            var result = enumProduct.getProductTypeEnumFromString(status);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void getProductTypeEnumFromStringTestOnInvalid()
        {
            string status = "asdfqwer";
            EnumProduct enumProduct = new EnumProduct();
            int? expected = null;
            var result = enumProduct.getProductTypeEnumFromString(status);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getProductStatusEnumFromStringTestLower()
        {
            string type = "activo";
            EnumProduct enumProduct = new EnumProduct();
            var expected = true;
            var result = enumProduct.getProductStatusEnumFromString(type);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void getProductStatusEnumFromStringTestUpper()
        {
            string type = "ACTIVO";
            EnumProduct enumProduct = new EnumProduct();
            var expected = true;
            var result = enumProduct.getProductStatusEnumFromString(type);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void getProductStatusEnumFromStringTestOnInvalid()
        {
            string type = "Deshabilitado";
            EnumProduct enumProduct = new EnumProduct();
            bool? expected = null;
            var result = enumProduct.getProductStatusEnumFromString(type);
            Assert.AreEqual(expected, result);
        }
    }
}