// File:    IPatientDao.cs
// Created: Thursday, May 14, 2020 4:56:47 PM
// Purpose: Definition of Interface IPatientDao

using Model.Patient;
using System;

namespace Dao.Users
{
   public interface IPatientDao : ICRUDDao<Patient, string>
   {
   }
}