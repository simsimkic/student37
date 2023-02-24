// File:    PrescriptionMedicineDao.cs
// Created: Wednesday, May 27, 2020 2:19:25 PM
// Purpose: Definition of Class PrescriptionMedicineDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Model.Doctor;
using Klinika.Database.Sequencer;

namespace Dao.Clinic.CSVImpl
{
    public class PrescriptionMedicineDao : IPrescriptionMedicineDao
    {
        private ICSVStream<PrescriptionMedicine> _stream;
        private ISequencer<long> _sequencer;

        public PrescriptionMedicineDao()
        {
            _stream = new CSVStream<PrescriptionMedicine>("..\\DB\\PrescriptionMedicinesDB.csv", new PrescriptionMedicineCSVConverter(","));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<PrescriptionMedicine> prescriptionMedicines)
        {
            return prescriptionMedicines.Count() == 0 ? 0 : prescriptionMedicines.Max(diag => diag.Id);
        }


        public int Count()
        => _stream.ReadAll().ToList().Count;

        public void Delete(PrescriptionMedicine prescriptionMedicine)
         => DeleteById(prescriptionMedicine.Id);

        public void DeleteAll()
         => _stream.SaveAll(new List<PrescriptionMedicine>());

        public void DeleteById(long id)
        {
            List<PrescriptionMedicine> prescriptionMedicines = _stream.ReadAll().ToList();
            PrescriptionMedicine toRemove = prescriptionMedicines.SingleOrDefault(pM => pM.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                prescriptionMedicines.Remove(toRemove);
                _stream.SaveAll(prescriptionMedicines);
            }
            else
            {
                Console.WriteLine("Lek iz recepta nije pronadjen");
            }
        }

        public bool ExistsById(long id)
         => FindById(id) == null ? false : true;

        public IEnumerable<PrescriptionMedicine> FindAll()
         => _stream.ReadAll().ToList();

        public PrescriptionMedicine FindById(long id)
         => FindAll().SingleOrDefault(pM => pM.Id.CompareTo(id) == 0);

        public PrescriptionMedicine Save(PrescriptionMedicine newMedicine)
        {
            List<PrescriptionMedicine> prescriptionMedicines = _stream.ReadAll().ToList();
            PrescriptionMedicine medicine = prescriptionMedicines.SingleOrDefault(pM => pM.Id.CompareTo(newMedicine.Id) == 0);
            if (medicine != null)
            {
                prescriptionMedicines[prescriptionMedicines.FindIndex(pM => pM.Id.CompareTo(newMedicine.Id) == 0)] = newMedicine;
                _stream.SaveAll(prescriptionMedicines);
            }
            else
            {
                newMedicine.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newMedicine);
            }
            return newMedicine;
        }

        public void SaveAll(IEnumerable<PrescriptionMedicine> newMedicines)
        {
            foreach (PrescriptionMedicine medicine in newMedicines)
            {
                Save(medicine);
            }
        }
    }
}