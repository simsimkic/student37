using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class AddressCSVConverter : ICSVConverter<Address>
    {
        private readonly string _delimiter;

        public AddressCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Address ConvertCSVFormatToEntity(string addressCSVFormat)
        {
            string[] tokens = addressCSVFormat.Split(_delimiter.ToCharArray());
            Address address = new Address(long.Parse(tokens[0]), tokens[1]);
            City city = new City(tokens[2]);
            Municipality municipality = new Municipality(tokens[3]);
            city.Municipality = municipality;
            Country country = new Country(tokens[4]);
            municipality.Country = country;
            address.City = city;
            return address;
            
        }

        public string ConvertEntityToCSVFormat(Address address)
        => string.Join(_delimiter,
            address.Id,
            address.StreetAndNumber,
            address.City.Name,
            address.City.Municipality.Name,
            address.City.Municipality.Country.Name
            );
    }
}
