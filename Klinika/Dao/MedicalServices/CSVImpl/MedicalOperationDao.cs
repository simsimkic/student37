// File:    MedicalOperationDao.cs
// Created: Wednesday, May 27, 2020 2:42:42 PM
// Purpose: Definition of Class MedicalOperationDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.MedicalServices;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Secretary;

namespace Dao.MedicalServices.CSVImpl
{
    public class MedicalOperationDao : IMedicalOperationDao
    {
        private readonly ICSVStream<MedicalOperation> _stream;
        private readonly ISequencer<long> _sequencer;
        public MedicalOperationDao(ICSVStream<MedicalOperation> stream, ISequencer<long> sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(MedicalOperation operation) => DeleteById(operation.Id);


        public void DeleteAll() => _stream.SaveAll(new List<MedicalOperation>());

        public void DeleteById(long id)
        {
            List<MedicalOperation> operations = _stream.ReadAll().ToList();
            MedicalOperation toRemove = operations.SingleOrDefault(o => o.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                operations.Remove(toRemove);
                _stream.SaveAll(operations);
            }
            else
            {
                Console.WriteLine("Operacija nije pronadjena");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;

        public IEnumerable<MedicalOperation> FindAll() => _stream.ReadAll().ToList();

        public MedicalOperation FindById(long id)
       => FindAll().SingleOrDefault(a => a.Id.CompareTo(id) == 0);

        public MedicalOperation Save(MedicalOperation newOperation)
        {
            List<MedicalOperation> operations = _stream.ReadAll().ToList();
            MedicalOperation operation = operations.SingleOrDefault(o => o.Id.CompareTo(newOperation.Id) == 0);
            if (operation != null)
            {
                operations[operations.FindIndex(a => a.Id.CompareTo(operation.Id) == 0)] = newOperation;
                _stream.SaveAll(operations);
            }
            else
            {
                newOperation.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newOperation);
            }
            return newOperation;
        }

        public void SaveAll(IEnumerable<MedicalOperation> newOperations)
        {
            foreach(MedicalOperation operation in newOperations)
            {
                Save(operation);
            }
        }


        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<MedicalOperation> operations)
        {
            return operations.Count() == 0 ? 0 : operations.Max(operation => operation.Id);
        }
    }
}