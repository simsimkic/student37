using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Users;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.User;

namespace Klinika.Dao.Users.CSVImpl
{
    public class AddressDao : IAddressDao
    {
        private readonly ICSVStream<Address> _stream;
        private readonly ICSVStream<City> _cityStream;
        private readonly ICSVStream<Municipality> _municipalityStream;
        private readonly ICSVStream<Country> _countryStream;
        private readonly ISequencer<long> _sequencer;
        public AddressDao(ICSVStream<Address> stream, ICSVStream<Municipality> municipalityStream, ICSVStream<City> cityStream, ICSVStream<Country> countryStream, ISequencer<long> sequencer)
        {
            _stream = stream;
            _municipalityStream = municipalityStream;
            _cityStream = cityStream;
            _countryStream = countryStream;
            _sequencer = sequencer;
            InitializeId();
        }
        public int Count() => _stream.ReadAll().ToList().Count();

        public void Delete(Address address) => DeleteById(address.Id);

        public void DeleteAll() => _stream.SaveAll(new List<Address>());

        public void DeleteById(long id)
        {
            List<Address> addresses = _stream.ReadAll().ToList();
            Address toRemove = addresses.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                addresses.Remove(toRemove);
                _stream.SaveAll(addresses);
            }
            else
            {
                Console.WriteLine("Adresa nije pronadjena");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;

        public IEnumerable<Address> FindAll() => _stream.ReadAll().ToList();

        public IEnumerable<Country> FindAllCountries() 
            => _countryStream.ReadAll().ToList();

        public Address FindById(long id)
        {
            List<Address> addresses = _stream.ReadAll().ToList();
            return addresses.SingleOrDefault(a => a.Id.CompareTo(id) == 0);
        }

        public IEnumerable<City> FindCitiesByMunicipality(Municipality municipality)
            => _cityStream.ReadAll().ToList()
            .FindAll(city => city.Municipality.Name.Equals(municipality.Name));

        public IEnumerable<Municipality> FindMunicipalitiesByCountry(Country country)
            => _municipalityStream.ReadAll().ToList()
            .FindAll(municipality => municipality.Country.Name.Equals(country.Name));

        public Address Save(Address newAddress)
        {
            List<Address> addresses = _stream.ReadAll().ToList();
            Address address = addresses.SingleOrDefault(a => a.Id.CompareTo(newAddress.Id) == 0);
            if (address != null)
            {
                addresses[addresses.FindIndex(a => a.Id.CompareTo(address.Id) == 0)] = newAddress;
                _stream.SaveAll(addresses);
            }
            else
            {
                newAddress.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newAddress);
            }
            return newAddress;
        }

        public void SaveAll(IEnumerable<Address> newAddresses)
        {
            foreach(Address address in newAddresses)
            {
                Save(address);
            }
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Address> addresses)
        {
            return addresses.Count() == 0 ? 0 : addresses.Max(record => record.Id);
        }
    }
}
