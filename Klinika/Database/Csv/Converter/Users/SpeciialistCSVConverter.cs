using Model.Doctor;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class SpecialistCSVConverter : ICSVConverter<Specialist>
    {
        private readonly string _delimiter;

        public SpecialistCSVConverter(string delimiter) {
            _delimiter = delimiter;
        }

        public Specialist ConvertCSVFormatToEntity(string specialistCSVFormat)
        {
            string[] tokens = specialistCSVFormat.Split(_delimiter.ToCharArray());
            Specialist specialist = new Specialist();
            specialist.Jmbg = tokens[0];
            specialist.Specialization.Id = long.Parse(tokens[1]);

            return specialist;
        }

        public string ConvertEntityToCSVFormat(Specialist specialist)
        => string.Join(_delimiter,
            specialist.Jmbg,
            specialist.Specialization.Id
            );

    }
}
