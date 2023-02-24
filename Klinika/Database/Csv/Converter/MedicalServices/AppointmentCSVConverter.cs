using Model.Doctor;
using Model.Manager;
using Model.Patient;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.MedicalServices
{
    public class AppointmentCSVConverter : ICSVConverter<Appointment>
    {
        private readonly string _delimiter;
        public AppointmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Appointment ConvertCSVFormatToEntity(string appointmentCSVFormat)
        {
            string[] tokens = appointmentCSVFormat.Split(_delimiter.ToCharArray());
            return new Appointment(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                (AppointmentType)Enum.Parse(typeof(AppointmentType), tokens[3]),
                new Room(tokens[4]),
                new Doctor(tokens[5]),
                new Patient(tokens[6]));
        }

        public string ConvertEntityToCSVFormat(Appointment appointment)
            => string.Join(_delimiter,
                appointment.Id,
                appointment.StartTime,
                appointment.EndTime,
                appointment.Type,
                appointment.Room.Id,
                appointment.Doctor.Jmbg,
                appointment.Patient.Jmbg);
    }
}
