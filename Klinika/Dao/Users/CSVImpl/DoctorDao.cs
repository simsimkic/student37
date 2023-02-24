// File:    DoctorDao.cs
// Created: Wednesday, May 27, 2020 2:44:55 PM
// Purpose: Definition of Class DoctorDao

using System;
using System.Collections.Generic;
using Model.Doctor;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Csv.Converter.Users;
using System.Linq;

namespace Dao.Users.CSVImpl
{
    public class DoctorDao : IDoctorDao
    {
        private readonly ICSVStream<Doctor> _stream;

        public DoctorDao(string path, string delimiter)
        {
            _stream = new CSVStream<Doctor>(path, new DoctorCSVConverter(delimiter));
        }

        public DoctorDao(ICSVStream<Doctor> stream)
        {
            _stream = stream;
        }

        public int Count()
            => _stream.ReadAll().ToList().Count;


        public void Delete(Doctor doctor)
            => DeleteById(doctor.Jmbg);

        public void DeleteAll()
             => _stream.SaveAll(new List<Doctor>());


       public void DeleteById(string jmbg)
        {
            List<Doctor> doctors = _stream.ReadAll().ToList();
            Doctor toRemove = doctors.SingleOrDefault(p => p.Jmbg.CompareTo(jmbg) == 0);
            if (toRemove != null)
            {
                doctors.Remove(toRemove);
                _stream.SaveAll(doctors);
            }
            else
            {
                Console.WriteLine("Doktor nije pronadjen");
            }
        }

     
        public bool ExistsById(string jmbg)
             => FindById(jmbg) == null ? false : true;

        public IEnumerable<Doctor> FindAll()
             => _stream.ReadAll().ToList();


        public Doctor FindById(string jmbg)
        {
            List<Doctor> doctors = _stream.ReadAll().ToList();
            return doctors.SingleOrDefault(p => p.Jmbg.CompareTo(jmbg) == 0);
        }

        public Doctor Save(Doctor doctor)
        {
            Doctor oldDoctor = FindById(doctor.Jmbg);
            if (oldDoctor != null) {
                Delete(oldDoctor);
            }
            _stream.AppendToFile(doctor);

            return doctor;
        }

        public void SaveAll(IEnumerable<Doctor> newDoctors)
        {
            foreach (Doctor doctor in newDoctors)
            {
                Save(doctor);
            }
        }
    }
}