// File:    ShiftDao.cs
// Created: Wednesday, May 27, 2020 7:27:26 PM
// Purpose: Definition of Class ShiftDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter;
using Klinika.Database.Csv.Converter.Employees;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Manager;

namespace Dao.Employees.CSVImpl
{
    public class ShiftDao : IShiftDao
    {
        private readonly ICSVStream<Shift> _stream;
        private ISequencer<long> _sequencer;

        public ShiftDao(string path, string delimiter)
        {
            _stream = new CSVStream<Shift>(path, new ShiftCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public ShiftDao(ICSVStream<Shift> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public ShiftDao(ICSVStream<Shift> stream)
        {
            _stream = stream;
        }

        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Shift shift) => DeleteById(shift.Id);

        public void DeleteAll() => SaveAll(new List<Shift>());

        public void DeleteById(long id)
        {
            List<Shift> shifts = _stream.ReadAll().ToList();
            Shift toDelete = shifts.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toDelete != null)
            {
                shifts.Remove(toDelete);
                _stream.SaveAll(shifts);
            }
            else
                Console.WriteLine("Shift not found!");
        }

        public bool ExistsById(long id) => FindById(id) != null ? true : false;

        public IEnumerable<Shift> FindAll() => _stream.ReadAll().ToList();

        public Shift FindById(long id)
            => FindAll().SingleOrDefault(r => r.Id.CompareTo(id) == 0);

        public Shift Save(Shift newShift)
        {
            List<Shift> shifts = _stream.ReadAll().ToList();
            Shift shift = shifts.SingleOrDefault(r => r.Id.CompareTo(newShift.Id) == 0);
            if (shift != null)
            {
                shifts[shifts.FindIndex(r => r.Id.CompareTo(newShift.Id) == 0)] = newShift;
                _stream.SaveAll(shifts);
            }
            else
            {
                newShift.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newShift);
            } 
            return newShift;
        }

        public void SaveAll(IEnumerable<Shift> shifts)
        {
            foreach (Shift s in shifts)
                Save(s);
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Shift> shifts)
        {
            return shifts.Count() == 0 ? 0 : shifts.Max(shift => shift.Id);
        }
    }
}