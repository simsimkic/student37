using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Text.RegularExpressions;

namespace WpfLekar.Validation
{


    public class JmbgValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                Regex regex = new Regex(@"[0-9]{13}");
                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molim Vas unesite JMBG u ispravnom formatu od 13 cifara.");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu. Pokušajte ponovo uneti");
            }
        }


       

            /*public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                try
                {
                    var s = value as string;
                    Regex regex = new Regex(@"^([\w\.\-|+])@([\w\-]+)((\.(\w){2,4})+)$");
                    if (regex.IsMatch(s))
                    {
                        return new ValidationResult(true, null);
                    }
                    return new ValidationResult(false, "Molim Vas unesite e-mail u ispravnom formatu");
                }
                catch {
                    return new ValidationResult(false, "Doslo je do greske!");
                }
            }*/

        }
    }
