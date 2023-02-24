// File:    RenovationDao.cs
// Created: Wednesday, May 27, 2020 6:19:05 PM
// Purpose: Definition of Class RenovationDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class RenovationDao : IRenovationDao
    {
        ICSVStream<Renovation> _stream;
        ISequencer<long> _sequencer;

        public RenovationDao(string path, string delimiter)
        {
            _stream = new CSVStream<Renovation>(path, new RenovationCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public RenovationDao(ICSVStream<Renovation> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Renovation renovation) => DeleteById(renovation.Id);

        public void DeleteAll() => SaveAll(new List<Renovation>());

        public void DeleteById(long id)
        {
            List<Renovation> renovations = _stream.ReadAll().ToList();
            Renovation toDelete = renovations.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toDelete != null)
            {
                renovations.Remove(toDelete);
                _stream.SaveAll(renovations);
            }
            else
            {
                Console.WriteLine("Renovation not found!");
            }
        }

        public bool ExistsById(long id) => FindById(id) != null ? true : false;

        public IEnumerable<Renovation> FindAll() => _stream.ReadAll().ToList();

        public Renovation FindById(long id)
            => FindAll().SingleOrDefault(r => r.Id.CompareTo(id) == 0);

        public Renovation Save(Renovation newRen)
        {
            List<Renovation> renovations = _stream.ReadAll().ToList();
            Renovation ren = renovations.SingleOrDefault(r => r.Id.CompareTo(newRen.Id) == 0);
            if (ren != null)
            {
                renovations[renovations.FindIndex(r => r.Id.CompareTo(ren.Id) == 0)] = newRen;
                _stream.SaveAll(renovations);
            }
            else
            {
                newRen.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newRen);
            }
            return newRen;
        }

        public void SaveAll(IEnumerable<Renovation> renovations)
        {
            foreach (Renovation ren in renovations)
                Save(ren);
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Renovation> renovations)
        {
            return renovations.Count() == 0 ? 0 : renovations.Max(r => r.Id);
        }
    }
}