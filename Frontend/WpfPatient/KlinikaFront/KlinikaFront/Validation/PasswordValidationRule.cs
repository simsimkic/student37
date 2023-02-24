using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KlinikaFront.Validation
{
    class PasswordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is string)
            {
                string password = (string)value;
                if (password.Length < 8) return new ValidationResult(false, "Lozinka mora biti duža od 8 znakova.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown exception occured.");
            }
        }
    }
}
