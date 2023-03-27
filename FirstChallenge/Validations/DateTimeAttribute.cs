using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace FirstChallengue.Validations
{

    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class DateTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            if (value is DateTime)
            {
                if ((DateTime) value > DateTime.UtcNow) return false;
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
