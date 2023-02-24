using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class SpecializationCSVConverter : ICSVConverter<Specialization>
    {
        private readonly string _delimiter;

        public SpecializationCSVConverter(string delimiter) {
            _delimiter = delimiter;
        }

        public Specialization ConvertCSVFormatToEntity(string specializationCSVFormat)
        {
            string[] tokens = specializationCSVFormat.Split(_delimiter.ToCharArray());
            Specialization specialization = new Specialization();
            specialization.Id = long.Parse(tokens[0]);
            specialization.Name = tokens[1];
            
            return specialization;
        }

        public string ConvertEntityToCSVFormat(Specialization specialization)
        => string.Join(_delimiter,
            specialization.Id,
            specialization.Name
            );
    }
}
