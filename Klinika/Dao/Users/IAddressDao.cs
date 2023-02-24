using Dao;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Dao.Users
{
    public interface IAddressDao : ICRUDDao<Address, long>
    {
        IEnumerable<Country> FindAllCountries();
        IEnumerable<Municipality> FindMunicipalitiesByCountry(Country country);
        IEnumerable<City> FindCitiesByMunicipality(Municipality municipality);
    }
}
