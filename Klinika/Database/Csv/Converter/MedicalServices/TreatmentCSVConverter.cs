using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.MedicalServices
{
    public class TreatmentCSVConverter : ICSVConverter<Treatment>
    {
        private readonly string _delimiter;

        public TreatmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Treatment ConvertCSVFormatToEntity(string treatmentCSVFormat)
        {
            string[] tokens = treatmentCSVFormat.Split(_delimiter.ToCharArray());
            Treatment treatment = new Treatment();
            treatment.Id = long.Parse(tokens[0]);
            treatment.Name = tokens[1];

            return treatment;
        }

        public string ConvertEntityToCSVFormat(Treatment treatment)
         => string.Join(_delimiter,
            treatment.Id,
            treatment.Name
            );
    }
}
