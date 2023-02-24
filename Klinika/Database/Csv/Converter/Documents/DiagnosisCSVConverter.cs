using Model.Doctor;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Documents
{
    public class DiagnosisCSVConverter : ICSVConverter<Diagnosis>
    {
        private readonly string _delimiter;

        public DiagnosisCSVConverter(string delimiter) {
            _delimiter = delimiter;
        }

        public Diagnosis ConvertCSVFormatToEntity(string diagnosisCSVFormat)
        {
            string[] tokens = diagnosisCSVFormat.Split(_delimiter.ToCharArray());
            Diagnosis diagnosis = new Diagnosis();
            diagnosis.Id = long.Parse(tokens[0]);
            diagnosis.Name = tokens[1];

            return diagnosis;
        }

        public string ConvertEntityToCSVFormat(Diagnosis diagnosis)
            => string.Join(_delimiter,
                diagnosis.Id,
                diagnosis.Name
                );     
    }
}
