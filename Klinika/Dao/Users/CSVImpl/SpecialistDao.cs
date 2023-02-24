// File:    SpecializationDao.cs
// Created: Wednesday, May 27, 2020 2:44:54 PM
// Purpose: Definition of Class SpecializationDao

using System;
using System.Collections.Generic;
using Model.Doctor;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Csv.Converter.Users;
using System.Linq;
using Klinika.Database.Sequencer;

namespace Dao.Users.CSVImpl
{
    public class SpecialistDao : ISpecialistDao
    {
        
        private readonly ICSVStream<Specialist> _stream;

        public SpecialistDao(string path, string delimiter)
        {
            _stream = new CSVStream<Specialist>(path, new SpecialistCSVConverter(delimiter));
        }

        public SpecialistDao(ICSVStream<Specialist> stream)
        {
            _stream = stream;
        }
        
        public int Count()
        => _stream.ReadAll().ToList().Count;

        public void Delete(Specialist specialist)
            => DeleteById(specialist.Jmbg);

        public void DeleteAll()
        => _stream.SaveAll(new List<Specialist>());

        public void DeleteById(string jmbg)
        {
            List<Specialist> specialist = _stream.ReadAll().ToList();
            Specialist toRemove = specialist.SingleOrDefault(p => p.Jmbg.CompareTo(jmbg) == 0);
            if (toRemove != null)
            {
                specialist.Remove(toRemove);
                _stream.SaveAll(specialist);
            }
            else
            {
                Console.WriteLine("Doktor nije pronadjen");
            }
        }

        public bool ExistsById(string jmbg)
             => FindById(jmbg) == null ? false : true;

        public IEnumerable<Specialist> FindAll()
             => _stream.ReadAll().ToList();


        public Specialist FindById(string jmbg)
        {
            List<Specialist> specialist = _stream.ReadAll().ToList();
            return specialist.SingleOrDefault(p => p.Jmbg.CompareTo(jmbg) == 0);
        }

        public Specialist Save(Specialist specialist)
        {
            Specialist oldSpecialist = FindById(specialist.Jmbg);
            if (oldSpecialist != null)
            {
                Delete(oldSpecialist);
            }
            _stream.AppendToFile(specialist);

            return specialist;
        }

        public void SaveAll(IEnumerable<Specialist> newSpecialists)
        {
            foreach (Specialist specialist in newSpecialists)
            {
                Save(specialist);
            }
        }
    }
}