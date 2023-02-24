using Model.Doctor;
using Model.Manager;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class DoctorCSVConverter : ICSVConverter<Doctor>
    {
        private readonly string _delimiter;

        public DoctorCSVConverter(string delimiter) {
            _delimiter = delimiter;
        }

        public Doctor ConvertCSVFormatToEntity(string doctorCSVFormat)
        {
            string[] tokens = doctorCSVFormat.Split(_delimiter.ToCharArray());
            Doctor doctor = new Doctor();
            List<Question> questions = new List<Question>();
            List<Vacation> vacations = new List<Vacation>();
            doctor.Jmbg = tokens[0];
            doctor.Room = new Room(tokens[1]);
            doctor.WorkTime = new WorkTime(long.Parse(tokens[2]));
            /*IdListCSVConverter.convertToLongList(tokens[3])
                .ForEach(id => vacations.Add(new Vacation(id)));
            IdListCSVConverter.convertToLongList(tokens[4])
                .ForEach(id => questions.Add(new Question(id)));*/

            return doctor;
        }

        public string ConvertEntityToCSVFormat(Doctor doctor)
        => string.Join(_delimiter,
            doctor.Jmbg,
            doctor.Room.Id,
            doctor.WorkTime.Id
            /*IdListCSVConverter.convertToCSVFormat(doctor.Vacations),
            IdListCSVConverter.convertToCSVFormat(doctor.Questions)*/
            );

    }
}
