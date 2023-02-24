using Model.Doctor;
using Model.Manager;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Documents
{
    public class MedicalRecordCSVConverter : ICSVConverter<MedicalRecord>
    {
        private readonly string _delimiter;
        public MedicalRecordCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public MedicalRecord ConvertCSVFormatToEntity(string medicalRecordCSVFormat)
        {
            string[] tokens = medicalRecordCSVFormat.Split(_delimiter.ToCharArray());
            List<Employment> employments = new List<Employment>();
            List<Ingredient> allergies = new List<Ingredient>();
            List<Diagnosis> pastIllnesses = new List<Diagnosis>();
            List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();
            IdListCSVConverter.convertToLongList(tokens[9])
                .ForEach(id => employments.Add(new Employment(id)));
            IdListCSVConverter.convertToLongList(tokens[10])
                .ForEach(id => allergies.Add(new Ingredient(id)));
            IdListCSVConverter.convertToLongList(tokens[11])
                .ForEach(id => pastIllnesses.Add(new Diagnosis(id)));
            IdListCSVConverter.convertToLongList(tokens[12])
                .ForEach(id => medicalExaminations.Add(new MedicalExamination(id)));
            return new MedicalRecord(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                new HealthCare(tokens[3], tokens[4], tokens[5], tokens[6], tokens[7], tokens[8]),
                employments,
                allergies,
                pastIllnesses,
                medicalExaminations
                );
        }

        public string ConvertEntityToCSVFormat(MedicalRecord medicalRecord)
            => string.Join(_delimiter,
            medicalRecord.Id,
            medicalRecord.HealthCardId,
            medicalRecord.Warning,
            medicalRecord.HealthCare.Workers,
            medicalRecord.HealthCare.WorkersMembers,
            medicalRecord.HealthCare.RetireeMembers,
            medicalRecord.HealthCare.FarmerMembers,
            medicalRecord.HealthCare.MilitaryMembers,
            medicalRecord.HealthCare.Other,
            IdListCSVConverter.convertToCSVFormat(medicalRecord.Employments),
            IdListCSVConverter.convertToCSVFormat(medicalRecord.Allergies),
            IdListCSVConverter.convertToCSVFormat(medicalRecord.PastIllnesses),
            IdListCSVConverter.convertToCSVFormat(medicalRecord.Examinations));
            
        
    }
}
