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
    class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var name = value as string;
                Regex regex = new Regex(@"[A-Za-zšŠđĐčČćĆ]+");
                if (regex.IsMatch(name))
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Moguće je koristiti samo slova!");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
        }
    }
}
