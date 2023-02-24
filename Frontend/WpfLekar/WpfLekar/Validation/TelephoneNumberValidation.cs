using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WpfLekar.Validation
{
    public class TelephoneNumberValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                Regex regex = new Regex(@"[0-9]");
                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molim Vas unesite broj telefona u ispravnom formatu npr. 064888921");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu. Pokušajte ponovo uneti");
            }
        }

    }
}
