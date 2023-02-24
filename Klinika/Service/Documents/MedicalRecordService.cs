// File:    MedicalRecordService.cs
// Created: Wednesday, May 13, 2020 6:47:25 PM
// Purpose: Definition of Class MedicalRecordService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Dao.Documents;
using Dao.Documents.CSVImpl;
using Dao.Users;
using Dao.Users.CSVImpl;
using Model.Doctor;
using Model.Manager;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Documents
{
    public class MedicalRecordService
    {
        private readonly IDiagnosisDao _diagnosisDao;
        private readonly IMedicalRecordDao _medicalRecordDao;
        private readonly IPatientDao _patientDao;
        private readonly IIngredientDao _ingredientDao;  

        public MedicalRecordService(IDiagnosisDao diagnosisDao, IMedicalRecordDao medicalRecordDao, IPatientDao patientDao, IIngredientDao ingredientDao)
        {
            _diagnosisDao = diagnosisDao;
            _medicalRecordDao = medicalRecordDao;
            _patientDao = patientDao;
            _ingredientDao = ingredientDao;
        }
        public Ingredient AddAllergyToRecord(MedicalRecord record, Ingredient ingredient)
        {
            record = _medicalRecordDao.FindById(record.Id);
            foreach (Ingredient i in record.Allergies)
            {
                if (i.Id == ingredient.Id)
                {
                    return null;
                }
            }
            record.Allergies.Add(ingredient);
            UpdateMedicalRecord(record);
            return ingredient;
        }
      
        public void RemoveAllergyFromRecord(MedicalRecord record, Ingredient ingredient)
        {
            record = _medicalRecordDao.FindById(record.Id);
            foreach(Ingredient i in record.Allergies)
            {
                if (i.Id == ingredient.Id)
                {
                    record.Allergies.Remove(i);
                    UpdateMedicalRecord(record);
                    return;
                }
            }
        }
      
        public List<Ingredient> GetPatientAllergies(Patient patient)
        {
            MedicalRecord record = GetMedicalRecord(patient);
            List<Ingredient> allergies = new List<Ingredient>();
            foreach (Ingredient i in _medicalRecordDao.FindById(record.Id).Allergies)
            {
                allergies.Add(_ingredientDao.FindById(i.Id));
            }
            return allergies;
        }

        public MedicalRecord UpdateMedicalRecord(MedicalRecord medicalRecord)
            => _medicalRecordDao.Save(medicalRecord);
      
        public List<Diagnosis> GetPastIllnesses(Patient patient)
        {
            MedicalRecord record = GetMedicalRecord(patient);
            List<Diagnosis> pastIllnesses = new List<Diagnosis>();
            foreach (Diagnosis d in _medicalRecordDao.FindById(record.Id).PastIllnesses)
            {
                pastIllnesses.Add(_diagnosisDao.FindById(d.Id));
            }
            return pastIllnesses;
        }

        public MedicalRecord GetMedicalRecord(Patient patient)
            => _medicalRecordDao.FindById(patient.MedicalRecord.Id);

        public MedicalRecord GetMedicalRecord(long id)
            => _medicalRecordDao.FindById(id);

        public MedicalRecord GetMedicalRecord(string jmbg)
        {
            Patient patient = _patientDao.FindById(jmbg);
            if (patient != null)
            {
                return GetMedicalRecord(patient);
            }
            else return null;
        }
      
        public MedicalRecord SetMedicalRecord(Patient patient, MedicalRecord record)
        {
            patient = _patientDao.FindById(patient.Jmbg);
            record.Id = patient.MedicalRecord.Id;
            MedicalRecord newRecord = UpdateMedicalRecord(record);
            patient.MedicalRecord = newRecord;
            _patientDao.Save(patient);
            return newRecord;
        }
   }
}