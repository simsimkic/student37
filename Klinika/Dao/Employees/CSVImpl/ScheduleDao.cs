// File:    ScheduleDao.cs
// Created: Wednesday, May 27, 2020 2:40:56 PM
// Purpose: Definition of Class ScheduleDao

using System;
using System.Collections.Generic;
using Model.Doctor;
using Model.Secretary;

namespace Dao.Employees.CSVImpl
{
    public class ScheduleDao : IScheduleDao
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> FindAll()
        {
            throw new NotImplementedException();
        }

        public Schedule FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Appointment FindFreeDoctorsAppointments(Doctor doctor, Appointment date)
        {
            throw new NotImplementedException();
        }

        public Schedule Save(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Schedule> entities)
        {
            throw new NotImplementedException();
        }
    }
}