// File:    MedicalTreatmentController.cs
// Created: Thursday, May 28, 2020 9:24:24 AM
// Purpose: Definition of Class TreatmentController

using Model.Doctor;
using Model.Patient;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class TreatmentController
   {
        private readonly TreatmentService _treatmentService;

        public TreatmentController(TreatmentService dao)
        {
            _treatmentService = dao;
        }

        public List<Treatment> GetAllTreatments()
          => _treatmentService.GetAllTreatments();

        public Treatment AddTreatment(Treatment treatment)
          => _treatmentService.AddTreatment(treatment);

   }
}