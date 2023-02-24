// File:    PatientTreatmentService.cs
// Created: Tuesday, May 19, 2020 6:01:44 PM
// Purpose: Definition of Class PatientTreatmentService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Model.Doctor;
using Model.Patient;
using Model.Secretary;
using Service.Documents;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
   public class PatientTreatmentService
   {
        MedicalRecordService _medicalRecordService;
        PatientExaminationService _patientExaminationService;
        ReferralLetterService _referralLetterService;
        IMedicalOperationDao _medicalOperationDao;

        public PatientTreatmentService(MedicalRecordService medicalRecordService, PatientExaminationService patientExaminationService, 
            ReferralLetterService referralLetterService, IMedicalOperationDao medicalOperationDao)
        {
            _medicalRecordService = medicalRecordService;
            _patientExaminationService = patientExaminationService;
            _referralLetterService = referralLetterService;
            _medicalOperationDao = medicalOperationDao;
        }
        public List<MedicalPrescription> ListMedicalPrescriptions(Patient patient)
        {
            List<MedicalPrescription> prescriptions = new List<MedicalPrescription>();
            _medicalRecordService.GetPastIllnesses(patient)
                .ForEach(pi => prescriptions.AddRange(pi.MedicalPrescription));
            return prescriptions;
            
        }

        public List<MedicalOperation> ListPatientOperations(Patient patient)
        {
            List<MedicalOperation> operations = new List<MedicalOperation>();
            foreach(ReferralLetter letter in _referralLetterService.GetPatientReferralLetters(patient))
            {
                if(letter.MedicalOperation != null)
                {
                    MedicalOperation medicalOperation = _medicalOperationDao.FindById(letter.MedicalOperation.Id);
                    operations.Add(medicalOperation);
                }
            }
            return operations;
        }
      
        public List<Treatment> ListTreatments(Patient patient)
        {
            throw new NotImplementedException();
        }
   
   }
}