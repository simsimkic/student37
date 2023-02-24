using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manager.Validation
{
    class PasswordValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string pass = (string)value;
                if (pass.Length < 8)
                    return new ValidationResult(false, "Lozinka mora sadržati najmanje 8 znakova");
                return new ValidationResult(true, null);
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
        }
    }
}
