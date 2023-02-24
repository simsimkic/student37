// File:    TreatmentDao.cs
// Created: Wednesday, May 27, 2020 2:42:43 PM
// Purpose: Definition of Class TreatmentDao

using System;
using System.Collections.Generic;
using Model.Doctor;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Klinika.Database.Csv.Converter.MedicalServices;
using System.Linq;

namespace Dao.MedicalServices.CSVImpl
{
    public class TreatmentDao : ITreatmentDao
    {
        private readonly ICSVStream<Treatment> _stream;
        private ISequencer<long> _sequencer;

        public TreatmentDao(string path, string delimiter)
        {
            _stream = new CSVStream<Treatment>(path, new TreatmentCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public TreatmentDao(ICSVStream<Treatment> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public TreatmentDao(ICSVStream<Treatment> stream)
        {
            _stream = stream;
            _sequencer = new LongSequencer();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Treatment> treatments)
        => treatments.Count() == 0 ? 0 : treatments.Max(tretment => tretment.Id);


        public int Count()
        => _stream.ReadAll().ToList().Count;

        public void Delete(Treatment treatment)
        => DeleteById(treatment.Id);

        public void DeleteAll()
        => _stream.SaveAll(new List<Treatment>());

        public void DeleteById(long id)
        {
            List<Treatment> treatments = _stream.ReadAll().ToList();
            Treatment toRemove = treatments.SingleOrDefault(t => t.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                treatments.Remove(toRemove);
                _stream.SaveAll(treatments);
            }
            else
            {
                Console.WriteLine("Treatman nije pronadjen");
            }
        }

        public bool ExistsById(long id)
        => FindById(id) == null ? false : true;

        public IEnumerable<Treatment> FindAll()
        => _stream.ReadAll().ToList();

        public Treatment FindById(long id)
        => FindAll().SingleOrDefault(a => a.Id.CompareTo(id) == 0);

        public Treatment Save(Treatment newTreatment)
        {
            List<Treatment> treatments = _stream.ReadAll().ToList();
            Treatment treatment = treatments.SingleOrDefault(t => t.Id.CompareTo(newTreatment.Id) == 0);
            if (treatment != null)
            {
                treatments[treatments.FindIndex(a => a.Id.CompareTo(treatment.Id) == 0)] = newTreatment;
                _stream.SaveAll(treatments);
            }
            else
            {
                newTreatment.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newTreatment);
            }
            return newTreatment;
        }

        public void SaveAll(IEnumerable<Treatment> newTreatments)
        {
            foreach (Treatment treatment in newTreatments)
            {
                Save(treatment);
            }
        }
    }
}