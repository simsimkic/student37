// File:    MedicalExaminationController.cs
// Created: Thursday, May 14, 2020 10:25:03 AM
// Purpose: Definition of Class DiagnosisController

using Dto;
using Model.Doctor;
using Service.Documents;
using System;
using System.Collections.Generic;

namespace Controller.Documents
{
   public class DiagnosisController
   {
        private readonly DiagnosisService _diagnosisService;

        public DiagnosisController(DiagnosisService service)
        {
            _diagnosisService = service;
        }

        public Diagnosis AddDiagnosis(Diagnosis diagnosis)
            => _diagnosisService.AddDiagnosis(diagnosis);

        public List<Diagnosis> GetAllDiagnosis()
            => _diagnosisService.GetAllDiagnosis();

        public Diagnosis GetDiagnosis(long diagnosis)
              => _diagnosisService.GetDiagnosis(diagnosis);

    }
}