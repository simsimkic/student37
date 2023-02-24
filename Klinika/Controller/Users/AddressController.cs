using Klinika.Service.Users;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Controller.Users
{
    public class AddressController
    {
        private readonly AddressService _service;

        public AddressController(AddressService service)
        {
            _service = service;
        }
        public IEnumerable<Country> GetAllCountries() => _service.GetAllCountries();

        public IEnumerable<City> GetCitiesByMunicipality(string municipality)
            => _service.getCitiesByMunicipality(municipality);

        public IEnumerable<Municipality> GetMunicipalitiesByCountry(string country)
            => _service.GetMunicipalitiesByCountry(country);
    }
}
