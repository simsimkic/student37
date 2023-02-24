// File:    MedicalTreatmentService.cs
// Created: Thursday, May 28, 2020 9:24:24 AM
// Purpose: Definition of Class MedicalTreatmentService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Model.Doctor;
using Model.Patient;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
   public class MedicalTreatmentService
   {
        private IMedicalTreatmentDao _medicalTreatmentDao;
        public MedicalTreatmentService(IMedicalTreatmentDao medicalTreatmentDao)
        {
            _medicalTreatmentDao = medicalTreatmentDao;
        }

        public List<MedicalTreatment> GetAllMedicalTreatments()
          =>(List<MedicalTreatment>) _medicalTreatmentDao.FindAll();

        public MedicalTreatment SaveMedicalTreatment(MedicalTreatment treatment)
          => _medicalTreatmentDao.Save(treatment);
   
   }
}