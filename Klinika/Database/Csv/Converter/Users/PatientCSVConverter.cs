using Model.Doctor;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter;
        public PatientCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Patient ConvertCSVFormatToEntity(string patientCSVFormat)
        {
            string[] tokens = patientCSVFormat.Split(_delimiter.ToCharArray());
            List<Question> questions = new List<Question>();
            IdListCSVConverter.convertToLongList(tokens[3])
                .ForEach(id => questions.Add(new Question(id)));
            return new Patient(
                tokens[0],
                (Sex)Enum.Parse(typeof(Sex), tokens[1]),
                (MaritalStatus)Enum.Parse(typeof(MaritalStatus), tokens[2]),
                questions,
                new Doctor(tokens[4]),
                new MedicalRecord(long.Parse(tokens[5]))
                );
        }

        public string ConvertEntityToCSVFormat(Patient patient)
        => string.Join(_delimiter,
            patient.Jmbg,
            patient.Sex,
            patient.MaritalStatus,
            IdListCSVConverter.convertToCSVFormat(patient.Questions),
            patient.PrefferedDoctor.Jmbg,
            patient.MedicalRecord.Id);
    }
}
