namespace FirstChallengue.Models
{
    public enum ProductType
    {
        Bienes = 0,
        Vehiculos = 1,
        Terrenos = 2,
        Apartamentos = 3,
    }
    public class EnumProduct
    {
        public List<string> productTypeEnum = new List<string>()
            {
                "Bienes",
                "Vehiculos",
                "Terrenos",
                "Apartamentos",
            };
        

        public List<string> productStatusEnum = new List<string>()
            {
                "Inactivo",
                "Activo",
            };

        public string GetProductStatusEnum(bool status)
        {
            int statusInt = status? 1 : 0 ;
            return productStatusEnum.ElementAt(statusInt);
        }

        public string GetProductTypeEnum(int type)
        {
            return productTypeEnum.ElementAt(type);
        }

        public ProductType? getProductTypeEnumFromString(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "bienes":
                    return ProductType.Bienes;
                case "vehiculos":
                    return ProductType.Vehiculos;
                case "terrenos":
                    return ProductType.Terrenos;
                case "apartamentos":
                    return ProductType.Apartamentos;
                default:
                    return null;
            }
        }

        public bool? getProductStatusEnumFromString(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "activo":
                    return true;
                case "inactivo":
                    return false;
                default:
                    return null;
            }
        }
    };
    
    }

