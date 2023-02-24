using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KlinikaFront.Validation
{
    class JmbgValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is string)
            {
                string jmbg = (string)value;
                if (jmbg.Length != 13) return new ValidationResult(false, "Neispravno unet JMBG.");
                long parsed;
                if (!long.TryParse(jmbg, out parsed)) return new ValidationResult(false, "Neispravno unet JMBG.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown exception occured");
            }
        }
    }
}
