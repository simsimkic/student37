// File:    MedicalRecordController.cs
// Created: Monday, May 11, 2020 2:21:13 PM
// Purpose: Definition of Class MedicalRecordController

using Model.Doctor;
using Model.Manager;
using Model.Patient;
using Service.Documents;
using System.Collections.Generic;

namespace Controller.Documents
{
    public class MedicalRecordController
    {
        private readonly MedicalRecordService _medicalRecordService;
        public MedicalRecordController(MedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        public MedicalRecord GetMedicalRecord(Patient patient)
            => _medicalRecordService.GetMedicalRecord(patient);

        public void AddAllergyToRecord(MedicalRecord record, Ingredient ingredient)
            => _medicalRecordService.AddAllergyToRecord(record, ingredient);

        public List<Diagnosis> GetPastIllnesses(Patient patient)
            => _medicalRecordService.GetPastIllnesses(patient);

        public MedicalRecord UpdateMedicalRecord(MedicalRecord medicalRecord)
            => _medicalRecordService.UpdateMedicalRecord(medicalRecord);

        public List<Ingredient> GetPatientAllergies(Patient patient)
            => _medicalRecordService.GetPatientAllergies(patient);

        public void RemoveAllergyFromRecord(MedicalRecord record, Ingredient ingredient)
            => _medicalRecordService.RemoveAllergyFromRecord(record, ingredient);

        public void SetMedicalRecord(Patient patient, MedicalRecord record)
            => _medicalRecordService.SetMedicalRecord(patient, record);
    }
}