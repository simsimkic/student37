using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WpfLekar.Validation
{
    public class PasswordValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                Regex regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*#?&])[a-zA-z\d@$!%*#?&]{8,}$");
                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite najmanje 8 karaktera, bar 1 poseban znak i 1 slovo.");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu. Pokušajte ponovo uneti");
            }
        }

    }
}
