// File:    PatientExaminationController.cs
// Created: Wednesday, May 13, 2020 5:14:42 PM
// Purpose: Definition of Class PatientExaminationController

using Dto;
using Model.Doctor;
using Model.Patient;
using Model.Secretary;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
    public class PatientExaminationController
    {
        private readonly PatientExaminationService _examinationService;

        public PatientExaminationController(PatientExaminationService patientExaminationService)
        {
            _examinationService = patientExaminationService;
        }
        public List<Appointment> ListUpcomingExaminations(Patient patient)
            => _examinationService.ListUpcomingExaminations(patient);


        public List<MedicalExamination> ListExaminationHistory(Patient patient)
            => _examinationService.ListExaminationHistory(patient);
    }
}