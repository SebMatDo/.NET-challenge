using FirstChallengue.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FirstChallengue.Validations;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FirstChallengue
{
    public partial class ProductFromJson
    {
        [JsonPropertyName("Description")]
        [MaxLength(255)]
        public string Description { get; set; } = null!;

        [JsonPropertyName("ProductType")]
        [ProductTypeAttribute(ErrorMessage ="Por favor utilice un tipo de producto valido (bienes, vehiculos, terrenos, apartamentos")]
        public string ProductType { get; set; } = null!;

        [JsonPropertyName("Value")]
        [Range(1, 1000000000, ErrorMessage = "Por favor utilice valores entre 1 y mil millones")]
        public decimal? Value { get; set; } = null!;

        [JsonPropertyName("DateOfBuy")]
        [DateTimeAttribute(ErrorMessage = "La fecha de compra no puede ser mayor al día de hoy")]
        public DateTime? DateOfBuy { get; set; } = null!;

        [JsonPropertyName("ProductStatus")]
        [ProductStatusAttribute(ErrorMessage = "Por favor utilice un tipo de estado de producto valido (activo, inactivo)")]
        public string ProductStatus { get; set; } = null!;

        private readonly EnumProduct _enum = new EnumProduct();
        public ProductFromJson(Product product)
        {
            DateOfBuy = product.DateOfBuy;
            Description = product.Description;
            ProductStatus = _enum.GetProductStatusEnum(product.ProductStatus);
            ProductType = _enum.GetProductTypeEnum(product.ProductType);
            Value = product.Value;
        }

        [JsonConstructor]
        public ProductFromJson()
        {
        }

        public bool ValidateProductType()
        {
            if (ProductType != null)
            {
                var ProductTypeValidation = _enum.getProductTypeEnumFromString(ProductType);
                if (ProductTypeValidation == null) return false;
                return true;
            }
            return true;
        }

        public bool ValidateProductStatus()
        {
            if (ProductStatus != null)
            {
                var ProductStatusValidation = _enum.getProductStatusEnumFromString(ProductStatus);
                if (ProductStatusValidation == null) return false;
                return true;
            }
            return true;
        }
        public bool ValidateValue()
        {
            if (Value != null)
            {
                if (Value < 1) return false;
                if (Value > 1000000000) return false;
            }
            return true;
        }

    }
}
