// File:    MedicalTreatmentDao.cs
// Created: Wednesday, May 27, 2020 2:42:43 PM
// Purpose: Definition of Class MedicalTreatmentDao

using System;
using System.Collections.Generic;
using Model.Doctor;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Klinika.Database.Csv.Converter.MedicalServices;
using System.Linq;

namespace Dao.MedicalServices.CSVImpl
{
    public class MedicalTreatmentDao : IMedicalTreatmentDao
    {
        private readonly ICSVStream<MedicalTreatment> _stream;
        private readonly ISequencer<long> _sequencer;

        public MedicalTreatmentDao( ICSVStream<MedicalTreatment> stream, ISequencer<long> sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public MedicalTreatmentDao(ICSVStream<MedicalTreatment> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public MedicalTreatmentDao(ICSVStream<MedicalTreatment> stream)
        {
            _stream = stream;
            _sequencer = new LongSequencer();
        }

        private void InitializeId()
         => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<MedicalTreatment> treatments)
        => treatments.Count() == 0 ? 0 : treatments.Max(tretment => tretment.Id);


        public int Count()
        => _stream.ReadAll().ToList().Count;

        public void Delete(MedicalTreatment treatment)
        => DeleteById(treatment.Id);

        public void DeleteAll()
        => _stream.SaveAll(new List<MedicalTreatment>());

        public void DeleteById(long id)
        {
            List<MedicalTreatment> treatments = _stream.ReadAll().ToList();
            MedicalTreatment toRemove = treatments.SingleOrDefault(t => t.Id.CompareTo(id) == 0);
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

        public IEnumerable<MedicalTreatment> FindAll()
        => _stream.ReadAll().ToList();

        public MedicalTreatment FindById(long id)
        => FindAll().SingleOrDefault(a => a.Id.CompareTo(id) == 0);

        public MedicalTreatment Save(MedicalTreatment newTreatment)
        {
            List<MedicalTreatment> treatments = _stream.ReadAll().ToList();
            MedicalTreatment treatment = treatments.SingleOrDefault(t => t.Id.CompareTo(newTreatment.Id) == 0);
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

        public void SaveAll(IEnumerable<MedicalTreatment> newTreatments)
        {
            foreach (MedicalTreatment treatment in newTreatments)
            {
                Save(treatment);
            }
        }
    }
}