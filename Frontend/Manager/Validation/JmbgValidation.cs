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
    class JmbgValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var jmbg = value as string;
                Regex regex = new Regex(@"[0-9]{13}");
                if (regex.IsMatch(jmbg))
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Pogrešan unos, unesite 13 cifara");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
            
        }
    }
}
