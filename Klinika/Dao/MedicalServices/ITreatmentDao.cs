// File:    IMedicalTreatmentDao.cs
// Created: Sunday, May 24, 2020 10:00:59 PM
// Purpose: Definition of Interface IMedicalTreatmentDao

using Model.Doctor;
using System;

namespace Dao.MedicalServices
{
   public interface ITreatmentDao : ICRUDDao<Treatment, long>
   {
   }
}