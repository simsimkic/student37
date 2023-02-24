// File:    IWorkTimeDao.cs
// Created: Wednesday, May 27, 2020 7:25:35 PM
// Purpose: Definition of Interface IWorkTimeDao


using Model.Doctor;
using Model.Manager;
using System;

namespace Dao.Employees
{
   public interface IWorkTimeDao : Dao.ICRUDDao<WorkTime, long>
   {
      WorkTime FindDoctorsWorkTime(Doctor doctor, DateTime date);
   
   }
}