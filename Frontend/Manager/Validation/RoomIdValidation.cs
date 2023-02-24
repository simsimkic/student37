using Controller.Clinic;
using Manager.Records;
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
    class RoomIdValidation : ValidationRule
    {
        private readonly RoomController _roomController;

        public RoomIdValidation()
        {
            var app = (App)Application.Current;
            _roomController = app.roomController;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (_roomController.GetRoom(value.ToString()) == null)
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
