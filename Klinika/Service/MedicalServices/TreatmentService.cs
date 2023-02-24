// File:    MedicalTreatmentService.cs
// Created: Thursday, May 28, 2020 9:24:24 AM
// Purpose: Definition of Class TreatmentService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Model.Doctor;
using Model.Patient;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
   public class TreatmentService
   {
      private readonly ITreatmentDao _treatmentDao;

        public TreatmentService(ITreatmentDao dao)
        {
            _treatmentDao = dao;
        }

        public List<Treatment> GetAllTreatments()
          =>(List<Treatment>) _treatmentDao.FindAll();

        public Treatment AddTreatment(Treatment treatment)
          => _treatmentDao.Save(treatment);
  
   }
}