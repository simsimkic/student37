using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class CityCSVConverter : ICSVConverter<City>
    {
        private readonly string _delimiter;
        public CityCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public City ConvertCSVFormatToEntity(string cityCSVFormat)
        {
            string[] tokens = cityCSVFormat.Split(_delimiter.ToCharArray());
            City city = new City(tokens[0]);
            city.Municipality = new Municipality(tokens[1]);
            return city;
        }

        public string ConvertEntityToCSVFormat(City city)
        => string.Join(_delimiter,
            city.Name,
            city.Municipality.Name);
    }
}
