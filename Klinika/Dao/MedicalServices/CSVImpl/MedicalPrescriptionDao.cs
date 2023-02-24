// File:    MedicalPrescriptionDao.cs
// Created: Thursday, May 28, 2020 6:30:57 PM
// Purpose: Definition of Class MedicalPrescriptionDao

using System;
using System.Collections.Generic;
using Model.Doctor;
using Model.Patient;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Csv.Converter.MedicalServices;
using Klinika.Database.Sequencer;
using System.Linq;

namespace Dao.MedicalServices.CSVImpl
{
    public class MedicalPrescriptionDao : IMedicalPrescriptionDao
    {
        private ICSVStream<MedicalPrescription> _stream;
        private ISequencer<long> _sequencer;

        public MedicalPrescriptionDao()
        {
            _stream = new CSVStream<MedicalPrescription>("..\\DB\\MedicalPrescriptionsDB.csv", new MedicalPrescriptionCSVConverter(","));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        private void InitializeId()
         => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<MedicalPrescription> prescriptions)
        => prescriptions.Count() == 0 ? 0 : prescriptions.Max(prescription => prescription.Id);

        public int Count()
         => _stream.ReadAll().ToList().Count;

        public void Delete(MedicalPrescription prescription)
         => DeleteById(prescription.Id);

        public void DeleteAll()
         => _stream.SaveAll(new List<MedicalPrescription>());

        public void DeleteById(long id)
        {
            List<MedicalPrescription> prescriptions = _stream.ReadAll().ToList();
            MedicalPrescription toRemove = prescriptions.SingleOrDefault(p => p.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                prescriptions.Remove(toRemove);
                _stream.SaveAll(prescriptions);
            }
            else
            {
                Console.WriteLine("Recept nije pronadjen");
            }
        }

        public bool ExistsById(long id)
         => FindById(id) == null ? false : true;

        public IEnumerable<MedicalPrescription> FindAll()
         => _stream.ReadAll().ToList();

        public MedicalPrescription FindById(long id)
        => FindAll().SingleOrDefault(a => a.Id.CompareTo(id) == 0);

        public MedicalPrescription Save(MedicalPrescription newPrescription)
        {
            List<MedicalPrescription> prescriptions = _stream.ReadAll().ToList();
            MedicalPrescription prescription = prescriptions.SingleOrDefault(o => o.Id.CompareTo(newPrescription.Id) == 0);
            if (prescription != null)
            {
                prescriptions[prescriptions.FindIndex(a => a.Id.CompareTo(prescription.Id) == 0)] = newPrescription;
                _stream.SaveAll(prescriptions);
            }
            else
            {
                newPrescription.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newPrescription);
            }
            return newPrescription;
        }

        public void SaveAll(IEnumerable<MedicalPrescription> newPrescriptions)
        {
            foreach (MedicalPrescription prescription in newPrescriptions)
            {
                Save(prescription);
            }
        }

        public void SaveMedicalPrescription(MedicalPrescription prescription, Patient patient)
        {
            throw new NotImplementedException();    // obrisati ??
        }
    }
}