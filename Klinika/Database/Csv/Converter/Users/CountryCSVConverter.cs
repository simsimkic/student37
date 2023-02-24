using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class CountryCSVConverter : ICSVConverter<Country>
    {
        public Country ConvertCSVFormatToEntity(string countryCSVFormat)
        => new Country(countryCSVFormat);

        public string ConvertEntityToCSVFormat(Country country)
        => country.Name;
    }
}
