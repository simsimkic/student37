// File:    RoomFuncDao.cs
// Created: Wednesday, May 27, 2020 2:19:12 PM
// Purpose: Definition of Class RoomFuncDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class RoomFuncDao : IRoomFuncDao
    {
        ICSVStream<Functionality> _stream;
        ISequencer<long> _sequencer;

        public RoomFuncDao(string path, string delimiter)
        {
            _stream = new CSVStream<Functionality>(path, new FunctionalityCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public RoomFuncDao(ICSVStream<Functionality> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Functionality funct) => DeleteById(funct.Id);

        public void DeleteAll() => SaveAll(new List<Functionality>());

        public void DeleteById(long id)
        {
            List<Functionality> functs = _stream.ReadAll().ToList();
            Functionality toDelete = functs.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toDelete != null)
            {
                functs.Remove(toDelete);
                _stream.SaveAll(functs);
            }
            else
            {
                Console.WriteLine("Functionality not found!");
            }
        }

        public bool ExistsById(long id) => FindById(id) != null ? true : false;

        public IEnumerable<Functionality> FindAll() => _stream.ReadAll().ToList();

        public Functionality FindById(long id)
            => FindAll().SingleOrDefault(f => f.Id.CompareTo(id) == 0);

        public Functionality FindByName(string name)
            => FindAll().SingleOrDefault(f => f.FuncName.CompareTo(name) == 0);


        public Functionality Save(Functionality newFunc)
        {
            List<Functionality> functs = _stream.ReadAll().ToList();
            Functionality dept = functs.SingleOrDefault(r => r.Id.CompareTo(newFunc.Id) == 0);
            if (dept != null)
            {
                functs[functs.FindIndex(r => r.Id.CompareTo(dept.Id) == 0)] = newFunc;
                _stream.SaveAll(functs);
            }
            else
            {
                newFunc.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newFunc);
            }
            return newFunc;
        }

        public void SaveAll(IEnumerable<Functionality> functs)
        {
            foreach (Functionality f in functs)
                Save(f);
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Functionality> funcs)
        {
            return funcs.Count() == 0 ? 0 : funcs.Max(f => f.Id);
        }
    }
}