using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manager.Validation
{
    class UsernameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var username = value as string;
                Regex regex = new Regex(@"[\w]+");
                if (regex.IsMatch(username))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Dozvoljeno je koristiti slova, brojeve i _");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu. Pokušajte ponovo uneti");
            }
        }
    }
}
