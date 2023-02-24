// File:    ISpecializationDAO.cs
// Created: Sunday, May 24, 2020 10:02:36 PM
// Purpose: Definition of Interface ISpecializationDAO

using Model.Doctor;
using System;

namespace Dao.Users
{
   public interface ISpecialistDao : Dao.ICRUDDao<Specialist, string>
   {
   }
}