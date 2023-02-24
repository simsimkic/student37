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
    class NumberFieldValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var num = (string)value;
                Regex regex = new Regex(@"^\d+$");
                if (regex.IsMatch(num))
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Dozvoljene su samo cifre!");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
            

        }
    }
}
