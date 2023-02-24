using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.MedicalServices
{
    public class MedicalTreatmentCSVConverter : ICSVConverter<MedicalTreatment>
    {
        private readonly string _delimiter;

        public MedicalTreatmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public MedicalTreatment ConvertCSVFormatToEntity(string treatmentCSVFormat)
        {
            string[] tokens = treatmentCSVFormat.Split(_delimiter.ToCharArray());
            MedicalTreatment treatment = new MedicalTreatment();
            List<Diagnosis> diagnosis = new List<Diagnosis>();
            treatment.Id = long.Parse(tokens[0]);
            treatment.Name = tokens[1];
            treatment.Note = tokens[2];
            IdListCSVConverter.convertToLongList(tokens[3])
                .ForEach(id => diagnosis.Add(new Diagnosis(id)));

            return treatment;
        }

        public string ConvertEntityToCSVFormat(MedicalTreatment treatment)
         => string.Join(_delimiter,
            treatment.Id,
            treatment.Name,
            treatment.Note,
            IdListCSVConverter.convertToCSVFormat(treatment.Diagnosis)
            );
    }
}
