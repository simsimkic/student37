// File:    MedicalTreatmentController.cs
// Created: Thursday, May 28, 2020 9:24:24 AM
// Purpose: Definition of Class MedicalTreatmentController

using Model.Doctor;
using Model.Patient;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class MedicalTreatmentController
   {
        private readonly MedicalTreatmentService _medicalTreatmentService;

        public MedicalTreatmentController(MedicalTreatmentService medicalTreatmentService)
        {
            _medicalTreatmentService = medicalTreatmentService;
        }

        public List<MedicalTreatment> GetAllMedicalTreatments()
            => _medicalTreatmentService.GetAllMedicalTreatments();

        public MedicalTreatment SaveMedicalTreatment(MedicalTreatment treatment)
              => _medicalTreatmentService.SaveMedicalTreatment(treatment);
      
      
   
   }
}