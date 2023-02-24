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
    class AddressValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var address = value as string;
                Regex regex = new Regex(@"[\w\s]+\s\d+,[\w\s]+,[\w\s]+,[\w\s]+");
                if (regex.IsMatch(address))
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Unesite u formatu: ulica broj, grad, opština, država");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
        }
    }
}
