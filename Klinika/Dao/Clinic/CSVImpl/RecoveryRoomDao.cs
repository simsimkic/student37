// File:    RecoveryRoomDao.cs
// Created: Wednesday, May 27, 2020 6:19:05 PM
// Purpose: Definition of Class RecoveryRoomDao

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Klinika.Database.Csv.Converter;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class RecoveryRoomDao : IRecoveryRoomDao
    {
        ICSVStream<RecoveryRoom> _stream;

        public RecoveryRoomDao(string path, string delimiter)
        {
            _stream = new CSVStream<RecoveryRoom>(path, new RecoveryRoomCSVConverter(delimiter));
        }

        public RecoveryRoomDao(ICSVStream<RecoveryRoom> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(RecoveryRoom rr) => DeleteById(rr.Id);

        public void DeleteAll() => SaveAll(new List<RecoveryRoom>());

        public void DeleteById(string id)
        {
            List<RecoveryRoom> rrs = _stream.ReadAll().ToList();
            RecoveryRoom toDelete = rrs.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toDelete != null)
            {
                rrs.Remove(toDelete);
                _stream.SaveAll(rrs);
            }
            else
            {
                Console.WriteLine("RecoveryRoom not found!");
            }
        }

        public bool ExistsById(string id) => FindById(id) != null ? true : false;

        public IEnumerable<RecoveryRoom> FindAll() => _stream.ReadAll().ToList();

        public RecoveryRoom FindById(string id)
            => FindAll().SingleOrDefault(r => r.Id.CompareTo(id) == 0);

        public RecoveryRoom Save(RecoveryRoom newRR)
        {
            List<RecoveryRoom> rrs = _stream.ReadAll().ToList();
            RecoveryRoom rr = rrs.SingleOrDefault(r => r.Id.CompareTo(newRR.Id) == 0);
            if (rr != null)
            {
                rrs[rrs.FindIndex(r => r.Id.CompareTo(rr.Id) == 0)] = newRR;
                _stream.SaveAll(rrs);
            }
            else
            {
                _stream.AppendToFile(newRR);
            }
            return newRR;
        }

        public void SaveAll(IEnumerable<RecoveryRoom> rrs)
        {
            foreach (RecoveryRoom rr in rrs)
                Save(rr);
        }
    }
}