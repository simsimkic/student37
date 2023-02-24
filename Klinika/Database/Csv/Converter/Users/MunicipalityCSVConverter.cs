using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class MunicipalityCSVConverter : ICSVConverter<Municipality>
    {
        private readonly string _delimiter;
        public MunicipalityCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Municipality ConvertCSVFormatToEntity(string municipalityCSVFormat)
        {
            string[] tokens = municipalityCSVFormat.Split(_delimiter.ToCharArray());
            Municipality municipality = new Municipality(tokens[0]);
            municipality.Country = new Country(tokens[1]);
            return municipality;
        }

        public string ConvertEntityToCSVFormat(Municipality municipality)
        => string.Join(_delimiter,
            municipality.Name,
            municipality.Country.Name);
    }
}
