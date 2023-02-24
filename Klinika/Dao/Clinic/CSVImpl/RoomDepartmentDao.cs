// File:    RoomDepartmentDao.cs
// Created: Wednesday, May 27, 2020 2:19:09 PM
// Purpose: Definition of Class RoomDepartmentDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class RoomDepartmentDao : IRoomDepartmentDao
    {
        ICSVStream<Department> _stream;
        ISequencer<long> _sequencer;

        public RoomDepartmentDao(string path, string delimiter)
        {
            _stream = new CSVStream<Department>(path, new DepartmentCSVConverter(delimiter));
            _sequencer = new LongSequencer();
            InitializeId();
        }

        public RoomDepartmentDao(ICSVStream<Department> stream, LongSequencer sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Department dept) => DeleteById(dept.Id);

        public void DeleteAll() => SaveAll(new List<Department>());

        public void DeleteById(long id)
        {
            List<Department> depts = _stream.ReadAll().ToList();
            Department toDelete = depts.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toDelete != null)
            {
                depts.Remove(toDelete);
                _stream.SaveAll(depts);
            }
            else
            {
                Console.WriteLine("Department not found!");
            }
        }

        public bool ExistsById(long id) => FindById(id) != null ? true : false;

        public IEnumerable<Department> FindAll() => _stream.ReadAll().ToList();

        public Department FindById(long id)
            => FindAll().SingleOrDefault(p => p.Id.CompareTo(id) == 0);

        public Department FindByName(string name)
            => FindAll().SingleOrDefault(d => d.DepName.CompareTo(name) == 0);


        public Department Save(Department newDept)
        {
            List<Department> depts = _stream.ReadAll().ToList();
            Department dept = depts.SingleOrDefault(r => r.Id.CompareTo(newDept.Id) == 0);
            if (dept != null)
            {
                depts[depts.FindIndex(r => r.Id.CompareTo(dept.Id) == 0)] = newDept;
                _stream.SaveAll(depts);
            }
            else
            {
                newDept.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newDept);
            }
            return newDept;
        }

        public void SaveAll(IEnumerable<Department> depts)
        {
            foreach (Department d in depts)
                Save(d);
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Department> depts)
        {
            return depts.Count() == 0 ? 0 : depts.Max(d => d.Id);
        }
    }
}