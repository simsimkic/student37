using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfLekar.Validation
{
    public class NameAndSurnameValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                Regex regex = new Regex(@"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$");
                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molim Vas unesite u ispravnom formatu gde su samo slova.");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu. Pokušajte ponovo uneti.");
            }
        }
    }
}
