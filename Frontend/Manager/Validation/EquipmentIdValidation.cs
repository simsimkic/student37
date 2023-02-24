using Controller.Clinic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Manager.Validation
{
    class EquipmentIdValidation : ValidationRule
    {
        private readonly EquipmentController _equipmentController;

        public EquipmentIdValidation()
        {
            var app = (App)Application.Current;
            _equipmentController = app.equipmentController;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            try
            {
                if (_equipmentController.GetEquipment(value.ToString()) == null)
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Već postoji u evidenciji!");
            }
            catch
            {
                return new ValidationResult(false, "Došlo je do greške u sistemu, pokušajte ponovo.");
            }
        }
    }
}
