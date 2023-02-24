// File:    MedicalRecordDao.cs
// Created: Wednesday, May 27, 2020 2:28:24 PM
// Purpose: Definition of Class MedicalRecordDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Documents;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Patient;

namespace Dao.Documents.CSVImpl
{
    public class MedicalRecordDao : IMedicalRecordDao
    {
        private ICSVStream<MedicalRecord> _stream;
        private ISequencer<long> _sequencer;
        public MedicalRecordDao(ICSVStream<MedicalRecord> stream, ISequencer<long> sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(MedicalRecord record) => DeleteById(record.Id);

        public void DeleteAll() => _stream.SaveAll(new List<MedicalRecord>());
        
        public void DeleteById(long id)
        {
            List<MedicalRecord> records = _stream.ReadAll().ToList();
            MedicalRecord toRemove = records.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                records.Remove(toRemove);
                _stream.SaveAll(records);
            }
            else
            {
                Console.WriteLine("Zdravstveni karton nije pronadjen");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;

        public IEnumerable<MedicalRecord> FindAll() => _stream.ReadAll().ToList();

        public MedicalRecord FindById(long id)
            => FindAll().SingleOrDefault(a => a.Id.CompareTo(id) == 0);

        public HealthCare FindHealthCareByRecord(long id)
        {
            List<MedicalRecord> records = _stream.ReadAll().ToList();
            MedicalRecord record = records.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if(record != null)
            {
                return record.HealthCare;
            }
            else
            {
                Console.WriteLine("Zdravstveni karton nije pronadjen");
                return null;
            }
        }

        public void RemoveHealthCareFromRecord(long id) 
            => SaveHealthCareToRecord(id, new HealthCare());

        public MedicalRecord Save(MedicalRecord newRecord)
        {
            
            List<MedicalRecord> records = _stream.ReadAll().ToList();
            MedicalRecord record = records.SingleOrDefault(r => r.Id.CompareTo(newRecord.Id) == 0);
            if (record != null)
            {
                records[records.FindIndex(r => r.Id.CompareTo(record.Id) == 0)] = newRecord;
                _stream.SaveAll(records);
            }
            else
            {
                newRecord.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newRecord);
            }
            return newRecord;
        }

        public void SaveAll(IEnumerable<MedicalRecord> newRecords)
        {
            foreach(MedicalRecord record in newRecords)
            {
                Save(record);
            }
        }

        public void SaveHealthCareToRecord(long id, HealthCare healthCare)
        {
            List<MedicalRecord> records = _stream.ReadAll().ToList();
            MedicalRecord record = records.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (record != null)
            {
                record.HealthCare = healthCare;
                Save(record);
            }
            else
            {
                Console.WriteLine("Zdravstveni karton nije pronadjen");
            }
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<MedicalRecord> records)
        {
           return records.Count() == 0 ? 0 : records.Max(record => record.Id);
        }
    }
}