// File:    MedicineDao.cs
// Created: Wednesday, May 27, 2020 2:19:25 PM
// Purpose: Definition of Class MedicineDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class MedicineDao : IMedicineDao
    {
        ICSVStream<Medicine> _stream;

        public MedicineDao(string path, string delimiter)
        {
            _stream = new CSVStream<Medicine>(path, new MedicineCSVConverter(delimiter));
        }
        public MedicineDao(ICSVStream<Medicine> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Medicine medicine) => DeleteById(medicine.Tag);

        public void DeleteAll() => SaveAll(new List<Medicine>());

        public void DeleteById(string id)
        {
            List<Medicine> medicines = _stream.ReadAll().ToList();
            Medicine toDelete = medicines.SingleOrDefault(r => r.Tag.CompareTo(id) == 0);
            if (toDelete != null)
            {
                medicines.Remove(toDelete);
                _stream.SaveAll(medicines);
            }
            else
                Console.WriteLine("Medicine not found");
        }

        public bool ExistsById(string id) => FindById(id) != null ? true : false;

        public IEnumerable<Medicine> FindAll() => _stream.ReadAll().ToList();

        public Medicine FindById(string id)
            => FindAll().SingleOrDefault(r => r.Tag.CompareTo(id) == 0);

        public Medicine Save(Medicine newMedicine)
        {
            List<Medicine> medicines = _stream.ReadAll().ToList();
            Medicine medicine = medicines.SingleOrDefault(r => r.Tag.CompareTo(newMedicine.Tag) == 0);
            if (medicine != null)
            {
                medicines[medicines.FindIndex(r => r.Tag.CompareTo(newMedicine.Tag) == 0)] = newMedicine;
                _stream.SaveAll(medicines);
            }
            else
                _stream.AppendToFile(newMedicine);
            return newMedicine;
        }

        public void SaveAll(IEnumerable<Medicine> medicines)
        {
            foreach (Medicine m in medicines)
                Save(m);
        }
    }
}