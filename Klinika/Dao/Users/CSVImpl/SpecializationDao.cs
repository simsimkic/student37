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
    public class SpecializationDao : ISpecializationDao
    {
        
        private readonly ICSVStream<Specialization> _stream;
        private ISequencer<long> _sequencer;

        public SpecializationDao(string path, string delimiter)
        {
            _stream = new CSVStream<Specialization>(path, new SpecializationCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public SpecializationDao(ICSVStream<Specialization> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public SpecializationDao(ICSVStream<Specialization> stream)
        {
            _stream = stream;
            _sequencer = new LongSequencer();
            InitializeId();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Specialization> specializations)
        => specializations.Count() == 0 ? 0 : specializations.Max(specialization => specialization.Id);
        
        public int Count()
        => _stream.ReadAll().ToList().Count;

        public void Delete(Specialization specialization)
        => DeleteById(specialization.Id);

        public void DeleteAll()
        => _stream.SaveAll(new List<Specialization>());

        public void DeleteById(long id)
        {
            List<Specialization> specializations = _stream.ReadAll().ToList();
            Specialization toRemove = specializations.SingleOrDefault(s => s.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                specializations.Remove(toRemove);
                _stream.SaveAll(specializations);
            }
            else
            {
                Console.WriteLine("Specijalnost nije pronadjena");
            }
        }

        public bool ExistsById(long id)
        => FindById(id) == null ? false : true;

        public IEnumerable<Specialization> FindAll()
        => _stream.ReadAll().ToList();

        public Specialization FindById(long id)
        => FindAll().SingleOrDefault(s => s.Id.CompareTo(id) == 0);

        public Specialization Save(Specialization newSpecialization)
        {
            List<Specialization> specializations = _stream.ReadAll().ToList();
            /*if (specializations == null) {
                specializations = new List<Specialization>();
            }*/
            Specialization specialization = specializations.SingleOrDefault(o => o.Id.CompareTo(newSpecialization.Id) == 0);
            if (specialization != null)
            {
                specializations[specializations.FindIndex(s => s.Id.CompareTo(specialization.Id) == 0)] = newSpecialization;
                _stream.SaveAll(specializations);
            }
            else
            {
                newSpecialization.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newSpecialization);
            }
            return newSpecialization;
        }

        public void SaveAll(IEnumerable<Specialization> newSpecializations)
        {
            foreach (Specialization specialization in newSpecializations)
            {
                Save(specialization);
            }
        }

        public Specialization FindByName(string name)
            => FindAll().SingleOrDefault(s => s.Name.CompareTo(name) == 0);
    }
}