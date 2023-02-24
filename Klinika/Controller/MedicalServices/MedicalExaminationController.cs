// File:    MedicalExaminationController.cs
// Created: Thursday, May 14, 2020 10:25:03 AM
// Purpose: Definition of Class MedicalExaminationController

using Dto;
using Model.Doctor;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class MedicalExaminationController
   {
        private readonly MedicalExaminationService _medicalExaminationService;

        public MedicalExaminationController(MedicalExaminationService medicalExaminationService)
        {
            _medicalExaminationService = medicalExaminationService;
        }

        public MedicalExamination SaveMedicalExamination(MedicalExamination examination)
            => _medicalExaminationService.SaveMedicalExamination(examination);


        public void RemoveMedicalExamination(MedicalExamination examination)
            => _medicalExaminationService.RemoveMedicalExamination(examination);

      
   }
}