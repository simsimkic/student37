using Klinika.Dao.Users;
using Klinika.Dao.Users.CSVImpl;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Service.Users
{  
    public class AddressService
    {
        private readonly IAddressDao _addressDao;

        public AddressService(IAddressDao addressDao)
        {
            _addressDao = addressDao;
        }
        
        public IEnumerable<Country> GetAllCountries()
            => _addressDao.FindAllCountries();

        public IEnumerable<City> getCitiesByMunicipality(string municipality)
            => _addressDao.FindCitiesByMunicipality(new Municipality(municipality));

        public IEnumerable<Municipality> GetMunicipalitiesByCountry(string country)
            => _addressDao.FindMunicipalitiesByCountry(new Country(country));

        public Address AddAddress(Address address)
            => _addressDao.Save(address);
    }
}
