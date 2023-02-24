using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KlinikaFront.Validation
{
    class UsernameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is string)
            {
                string username = (string)value;
                if (!username.All(c => char.IsLetterOrDigit(c) || c == '_'))
                {
                    return new ValidationResult(false, "Korisničko ime sme da sadrži slova, brojeve i \"_\".");
                }
                else return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown exception occured.");
            }
        }
    }
}
