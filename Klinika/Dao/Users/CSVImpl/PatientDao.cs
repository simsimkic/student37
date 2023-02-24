// File:    PatientDao.cs
// Created: Wednesday, May 27, 2020 2:44:55 PM
// Purpose: Definition of Class PatientDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Users;
using Klinika.Database.Csv.Stream;
using Model.Patient;

namespace Dao.Users.CSVImpl
{
    public class PatientDao : IPatientDao
    {
        private readonly ICSVStream<Patient> _stream;
        public PatientDao(ICSVStream<Patient> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Patient patient) => DeleteById(patient.Jmbg);

        public void DeleteAll() => _stream.SaveAll(new List<Patient>());

        public void DeleteById(string jmbg)
        {
            List<Patient> patients = _stream.ReadAll().ToList();
            Patient toRemove = patients.SingleOrDefault(p => p.Jmbg.CompareTo(jmbg) == 0);
            if (toRemove != null)
            {
                patients.Remove(toRemove);
                _stream.SaveAll(patients);
            }
            else
            {
                Console.WriteLine("Pacijent nije pronadjen");
            }
        }

        public bool ExistsById(string jmbg)
            => FindById(jmbg) == null ? false : true;


        public IEnumerable<Patient> FindAll() => _stream.ReadAll().ToList();

        public Patient FindById(string jmbg)
        {
            List<Patient> patients = _stream.ReadAll().ToList();
            return patients.SingleOrDefault(p => p.Jmbg.CompareTo(jmbg) == 0);
        }

        public Patient Save(Patient patient)
        {
            Patient oldPatient = FindById(patient.Jmbg);
            if (oldPatient != null)
            {
                Delete(oldPatient);
            }
            _stream.AppendToFile(patient);
            return patient;
        }

        public void SaveAll(IEnumerable<Patient> newPatients)
        {
            foreach (Patient patient in newPatients)
            {
                Save(patient);
            }
        }
    }
}