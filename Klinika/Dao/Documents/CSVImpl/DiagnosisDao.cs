// File:    DiagnosisDao.cs
// Created: Wednesday, May 27, 2020 3:25:05 PM
// Purpose: Definition of Class DiagnosisDao

using System;
using System.Collections.Generic;
using Model.Doctor;
using Klinika.Database.Sequencer;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Csv.Converter.Documents;
using System.Linq;

namespace Dao.Documents.CSVImpl
{
    public class DiagnosisDao : IDiagnosisDao
    {

        private readonly ICSVStream<Diagnosis> _stream;
        private ISequencer<long> _sequencer;

        public DiagnosisDao(string path, string delimiter)
        {
            _stream = new CSVStream<Diagnosis>(path, new DiagnosisCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public DiagnosisDao(ICSVStream<Diagnosis> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public DiagnosisDao(ICSVStream<Diagnosis> stream)
        {
            _stream = stream;
            _sequencer = new LongSequencer();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Diagnosis> diagnosis)
        {
            return diagnosis.Count() == 0 ? 0 : diagnosis.Max(diag => diag.Id);
        }

        public int Count() => _stream.ReadAll().ToList().Count;


        public void Delete(Diagnosis diagnosis) => DeleteById(diagnosis.Id);


        public void DeleteAll() => _stream.SaveAll(new List<Diagnosis>());


        public void DeleteById(long id)
        {
            List<Diagnosis> diagnosis = _stream.ReadAll().ToList();
            Diagnosis toRemove = diagnosis.SingleOrDefault(q => q.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                diagnosis.Remove(toRemove);
                _stream.SaveAll(diagnosis);
            }
            else
            {
                Console.WriteLine("Dijagnoza nije pronadjena");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;


        public IEnumerable<Diagnosis> FindAll() => _stream.ReadAll().ToList();
        

        public Diagnosis FindById(long id) => FindAll().SingleOrDefault(q => q.Id.CompareTo(id) == 0);


        public Diagnosis Save(Diagnosis newDiag)
        {
            List<Diagnosis> diagnosis = _stream.ReadAll().ToList();
            Diagnosis diag = diagnosis.SingleOrDefault(q => q.Id.CompareTo(newDiag.Id) == 0);
            if (diag != null)
            {
                diagnosis[diagnosis.FindIndex(q => q.Id.CompareTo(diag.Id) == 0)] = newDiag;
                _stream.SaveAll(diagnosis);
            }
            else
            {
                newDiag.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newDiag);
            }
            return newDiag;
        }

        public void SaveAll(IEnumerable<Diagnosis> newDiags)
        {
            foreach (Diagnosis diag in newDiags)
            {
                Save(diag);
            }
        }
    }
}