using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using FirstChallengue.Models;
namespace FirstChallengue.Validations
{

    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class ProductStatusAttribute : ValidationAttribute
    {
        private readonly EnumProduct _enum = new EnumProduct();
        public override bool IsValid(object value)
        {
            bool result = true;
            if (value == null) return false;
            if (value is string)
            {
                bool? status = _enum.getProductStatusEnumFromString((string) value);
                if (status == null) return false;
                return result;
            }
            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }

    }
}
