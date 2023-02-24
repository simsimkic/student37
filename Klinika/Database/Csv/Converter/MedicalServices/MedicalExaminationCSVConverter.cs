using Model.Doctor;
using Model.Patient;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.MedicalServices
{
    public class MedicalExaminationCSVConverter : ICSVConverter<MedicalExamination>
    {
        private readonly string _delimiter;

        public MedicalExaminationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public MedicalExamination ConvertCSVFormatToEntity(string examinationCSVFormat)
        {
            string[] tokens = examinationCSVFormat.Split(_delimiter.ToCharArray());
            List<Diagnosis> diagnosis = new List<Diagnosis>();
            IdListCSVConverter.convertToStringList(tokens[8])
               .ForEach(id => diagnosis.Add(new Diagnosis(id)));
            return new MedicalExamination(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                Boolean.Parse(tokens[3]),
                new ReferralLetter(long.Parse(tokens[4])),
                new MedicalRecord(long.Parse(tokens[5])),
                new Doctor(tokens[6]),
                new Appointment(tokens[7]),
                diagnosis,
                new MedicalPrescription(long.Parse(tokens[9])),
                new MedicalTreatment(long.Parse(tokens[10]))
                );
            
        }

        public string ConvertEntityToCSVFormat(MedicalExamination examination)
        => string.Join(_delimiter,
            examination.Id,
            examination.MainSimptoms,
            examination.ObjectiveExamination,
            examination.Status,
            examination.ReferralLetter.Id,
            examination.MedicalRecord.Id,
            examination.Doctor.Jmbg,
            examination.Appointment.Id,
            IdListCSVConverter.convertToCSVFormat(examination.Diagnosis),
            examination.MedicalPrescription.Id,
            examination.MedicalTreatment.Id
            );
    }
}
