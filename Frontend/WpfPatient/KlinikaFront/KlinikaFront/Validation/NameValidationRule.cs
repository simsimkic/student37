using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KlinikaFront.Validation
{
    class NameValidationRule : ValidationRule
    {
        public string Field { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is string)
            {
                string name = (string)value;
                if (name.All(char.IsLetter)) return new ValidationResult(true, null);
                else return new ValidationResult(false, "Neispravno uneto " + Field + ".");
            }
            else
            {
                return new ValidationResult(false, "Unknown exception occured.");
            }
        }
    }
}
