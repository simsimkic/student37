using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manager.Validation
{
    class PhoneValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var phone = value as string;
                Regex regex = new Regex(@"^[+]\d{3}\/[\d\-\/\s]+\d$");
                if (regex.IsMatch(phone))
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Pogrešan unos, unesite u formatu +000/00000000");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
        }
    }
}
