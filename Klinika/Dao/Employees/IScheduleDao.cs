// File:    IScheduleDao.cs
// Created: Sunday, May 24, 2020 9:48:39 PM
// Purpose: Definition of Interface IScheduleDao

using Model.Doctor;
using Model.Secretary;
using System;

namespace Dao.Employees
{
   public interface IScheduleDao : ICRUDDao<Schedule, long>
   {
      Appointment FindFreeDoctorsAppointments(Doctor doctor, Appointment date);
   
   }
}