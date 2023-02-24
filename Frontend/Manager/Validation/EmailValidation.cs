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
    class EmailValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var email = value as string;
                Regex regex = new Regex(@"^[a-zA-Z]\S+[a-zA-Z]@[a-zA-Z][^\s\.]\.[a-zA-Z][^\s][a-zA-Z]");
                if (regex.IsMatch(email))
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Neispravan format. Unesite u formatu email@example.com");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
        }
    }
}
