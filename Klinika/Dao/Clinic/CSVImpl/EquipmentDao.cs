// File:    EquipmentDao.cs
// Created: Wednesday, May 27, 2020 2:19:11 PM
// Purpose: Definition of Class EquipmentDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class EquipmentDao : IEquipmentDao
    {
        private ICSVStream<Equipment> _stream;

        public EquipmentDao(string path, string delimiter)
        {
            _stream = new CSVStream<Equipment>(path, new EquipmentCSVConverter(delimiter));
        }
        public EquipmentDao(ICSVStream<Equipment> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Equipment equipment) => DeleteById(equipment.EquipmentID);

        public void DeleteAll() => SaveAll(new List<Equipment>());

        public void DeleteById(string id)
        {
            List<Equipment> allEquipment = _stream.ReadAll().ToList();
            Equipment toRemove = allEquipment.SingleOrDefault(r => r.EquipmentID.CompareTo(id) == 0);
            if (toRemove != null)
            {
                allEquipment.Remove(toRemove);
                _stream.SaveAll(allEquipment);
            }
            else
                Console.WriteLine("Equipment not found!");
        }

        public bool ExistsById(string id) => FindById(id) != null ? true : false;

        public IEnumerable<Equipment> FindAll() => _stream.ReadAll().ToList();

        public Equipment FindById(string id)
            => FindAll().SingleOrDefault(r => r.EquipmentID.CompareTo(id) == 0);

        public Equipment Save(Equipment newEquipment)
        {
            List<Equipment> allEquipment = _stream.ReadAll().ToList();
            Equipment equip = allEquipment.SingleOrDefault(r => r.EquipmentID.CompareTo(newEquipment.EquipmentID) == 0);
            if (equip != null)
            {
                allEquipment[allEquipment.FindIndex(r => r.EquipmentID.CompareTo(newEquipment.EquipmentID) == 0)] = newEquipment;
                _stream.SaveAll(allEquipment);
            }
            else
                _stream.AppendToFile(newEquipment);
            return newEquipment;
        }

        public void SaveAll(IEnumerable<Equipment> equipments)
        {
            foreach (Equipment e in equipments)
                Save(e);
        }
    }
}