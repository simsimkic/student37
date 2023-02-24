// File:    SecretaryDao.cs
// Created: Wednesday, May 27, 2020 2:44:54 PM
// Purpose: Definition of Class SecretaryDao

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Klinika.Database.Csv.Converter.Users;
using Klinika.Database.Csv.Stream;
using Model.Secretary;

namespace Dao.Users.CSVImpl
{
    public class SecretaryDao : ISecretaryDao
    {
        private ICSVStream<Secretary> _stream;
        public SecretaryDao(ICSVStream<Secretary> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Secretary entity) => DeleteById(entity.Jmbg);

        public void DeleteAll() => _stream.SaveAll(new List<Secretary>());

        public void DeleteById(string jmbg)
        {
            List<Secretary> secretaries = _stream.ReadAll().ToList();
            Secretary toRemove = secretaries.SingleOrDefault(s => s.Jmbg.Equals(jmbg));
            if (toRemove != null)
            {
                secretaries.Remove(toRemove);
                _stream.SaveAll(secretaries);
            }
            else
            {
                Console.WriteLine("Nije pronadjen sekretar");
            }
 
        }

        public bool ExistsById(string jmbg) => FindById(jmbg) == null ? false : true;

        public IEnumerable<Secretary> FindAll() => _stream.ReadAll().ToList();

        public Secretary FindById(string jmbg)
        {
            List<Secretary> secretaries = _stream.ReadAll().ToList();
            return  secretaries.SingleOrDefault(s => s.Jmbg.Equals(jmbg));
        }

        public Secretary Save(Secretary secretary)
        {
            Secretary oldSecretary = FindById(secretary.Jmbg);
            if (oldSecretary != null)
            {
                Delete(secretary);
            }
            _stream.AppendToFile(secretary);
            return secretary;
        }

        public void SaveAll(IEnumerable<Secretary> newSecretaries)
        {
            foreach(Secretary secretary in newSecretaries)
            {
                Save(secretary);
            }
        }
    }
}