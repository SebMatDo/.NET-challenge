using FirstChallengue.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstChallengue
{
    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int ProductType { get; set; }
        
        [Required]
        public decimal Value { get; set; }
        
        [Required]
        public DateTime DateOfBuy { get; set; }
       
        [Required]
        public bool ProductStatus { get; set; }

        private readonly EnumProduct _enum = new EnumProduct();

        public Product()
        {

        }

        public Product (ProductFromJson product)
        {
            Description = product.Description;
            ProductType = (int)_enum.getProductTypeEnumFromString(product.ProductType).Value;
            Value = product.Value.Value;
            DateOfBuy = product.DateOfBuy.Value;
            ProductStatus = (bool)_enum.getProductStatusEnumFromString(product.ProductStatus).Value;
           
        }
        public void updateInformation(ProductFromJson product)
        {
            if (product.Description != null) Description = product.Description;
            if (product.ProductType != null) ProductType = (int)_enum.getProductTypeEnumFromString(product.ProductType).Value;
            if (product.ProductStatus != null) ProductStatus = (bool)_enum.getProductStatusEnumFromString(product.ProductStatus).Value;
            if (product.Value != null) Value = product.Value.Value;
            if (product.DateOfBuy != null) DateOfBuy = product.DateOfBuy.Value;
        }
    }
}
