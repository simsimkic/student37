// File:    PatientTreatmentController.cs
// Created: Tuesday, May 19, 2020 6:01:44 PM
// Purpose: Definition of Class PatientTreatmentController

using Model.Doctor;
using Model.Secretary;
using Service.MedicalServices;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
    public class PatientTreatmentController
    {
        public PatientTreatmentService _patientTreatmentService;

        public PatientTreatmentController(PatientTreatmentService patientTreatmentService)
        {
            _patientTreatmentService = patientTreatmentService;
        }
        public List<MedicalPrescription> ListMedicalPrescriptions(Model.Patient.Patient patient)
            => _patientTreatmentService.ListMedicalPrescriptions(patient);

        public List<MedicalOperation> ListOperations(Model.Patient.Patient patient)
            => _patientTreatmentService.ListPatientOperations(patient);

        public List<Treatment> ListTreatments(Model.Patient.Patient patient)
            => _patientTreatmentService.ListTreatments(patient);



    }
}