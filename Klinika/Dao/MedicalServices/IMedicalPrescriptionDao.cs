// File:    IMedicalPrescriptionDao.cs
// Created: Thursday, May 28, 2020 6:29:39 PM
// Purpose: Definition of Interface IMedicalPrescriptionDao

using Model.Doctor;
using Model.Patient;
using System;

namespace Dao.MedicalServices
{
   public interface IMedicalPrescriptionDao : ICRUDDao<MedicalPrescription, long>
   {
        
        
   }
}