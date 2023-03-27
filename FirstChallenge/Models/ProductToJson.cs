using FirstChallengue.Models;
using System;
using System.Collections.Generic;

namespace FirstChallengue
{
    public partial class ProductToJson
    {
        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public decimal Value { get; set; }
        public DateTime DateOfBuy { get; set; }
        public string ProductStatus { get; set; } = null!;

        private readonly EnumProduct _enum = new EnumProduct();
        public ProductToJson(Product product)
        {

            Id = product.Id;
            DateOfBuy = product.DateOfBuy;
            Description = product.Description;
            ProductStatus = _enum.GetProductStatusEnum(product.ProductStatus);
            ProductType = _enum.GetProductTypeEnum(product.ProductType);
            Value = product.Value;
        }

        public ProductToJson()
        {

        }

    }
}
