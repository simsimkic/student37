// File:    IDoctorDao.cs
// Created: Sunday, May 24, 2020 10:02:36 PM
// Purpose: Definition of Interface IDoctorDao

using Model.Doctor;
using System;

namespace Dao.Users
{
   public interface IDoctorDao : ICRUDDao<Doctor, string>
   {
    
   
   }
}