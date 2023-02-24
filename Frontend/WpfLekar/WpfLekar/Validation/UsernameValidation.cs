using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using Model.User;

namespace WpfLekar.Validation
{
    public class UsernameValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{3,9}$");
                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite najmanje 3 karaktera, a najviše 8. ");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu. Pokušajte ponovo uneti");
            }
        }

    }
}
