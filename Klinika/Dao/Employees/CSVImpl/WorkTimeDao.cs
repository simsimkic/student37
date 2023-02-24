// File:    WorkTimeDao.cs
// Created: Wednesday, May 27, 2020 7:27:26 PM
// Purpose: Definition of Class WorkTimeDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Employees;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Doctor;
using Model.Manager;

namespace Dao.Employees.CSVImpl
{
    public class WorkTimeDao : IWorkTimeDao     
    {
        private readonly ICSVStream<WorkTime> _stream;
        private ISequencer<long> _sequencer;

        public WorkTimeDao(string path, string delimiter)
        {
            _stream = new CSVStream<WorkTime>(path, new WorkTimeCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public WorkTimeDao(ICSVStream<WorkTime> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public WorkTimeDao(ICSVStream<WorkTime> stream)
        {
            _stream = stream;

        }

        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(WorkTime wt) => DeleteById(wt.Id);

        public void DeleteAll() => SaveAll(new List<WorkTime>());

        public void DeleteById(long id)
        {
            List<WorkTime> wtimes = _stream.ReadAll().ToList();
            WorkTime toDelete = wtimes.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toDelete != null)
            {
                wtimes.Remove(toDelete);
                _stream.SaveAll(wtimes);
            }
            else
            {
                Console.WriteLine("WorkTime not found!");
            }
        }

        public bool ExistsById(long id) => FindById(id) != null ? true : false;

        public IEnumerable<WorkTime> FindAll() => _stream.ReadAll().ToList();

        public WorkTime FindById(long id)
            => FindAll().SingleOrDefault(r => r.Id.CompareTo(id) == 0);

        public WorkTime Save(WorkTime newWt)
        {
            List<WorkTime> wtimes = _stream.ReadAll().ToList();
            WorkTime wt = wtimes.SingleOrDefault(r => r.Id.CompareTo(newWt.Id) == 0);
            if(wt != null)
            {
                wtimes[wtimes.FindIndex(r => r.Id.CompareTo(newWt.Id) == 0)] = newWt;
                _stream.SaveAll(wtimes);
            }
            else
            {
                newWt.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newWt);
            }
            return newWt;
        }

        public void SaveAll(IEnumerable<WorkTime> wtimes)
        {
            foreach (WorkTime wt in wtimes)
                Save(wt);
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<WorkTime> wtimes)
        {
            return wtimes.Count() == 0 ? 0 : wtimes.Max(wt => wt.Id);
        }

        public WorkTime FindDoctorsWorkTime(Doctor doctor, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}