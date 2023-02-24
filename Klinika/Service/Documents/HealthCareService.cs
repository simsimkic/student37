// File:    HealthCareService.cs
// Created: Tuesday, May 26, 2020 7:44:36 PM
// Purpose: Definition of Class HealthCareService

using Dao.Documents;
using Dao.Documents.CSVImpl;
using Model.Patient;
using System;

namespace Service.Documents
{
   public class HealthCareService
   {
        private readonly IMedicalRecordDao _medicalRecordDao;
        private readonly MedicalRecordService _medicalRecordService;

        public HealthCareService(IMedicalRecordDao medicalRecordDao, MedicalRecordService medicalRecordService)
        {
            _medicalRecordDao = medicalRecordDao;
            _medicalRecordService = medicalRecordService;
        }
        public HealthCare SetHealthCare(string jmbg, HealthCare healthCare)
        {
            MedicalRecord record = _medicalRecordService.GetMedicalRecord(jmbg);
            if(record != null)
            {
                _medicalRecordDao.SaveHealthCareToRecord(record.Id, healthCare);
                return healthCare;
            }
            return null;
        }

        public HealthCare GetHealthCare(string jmbg)
        {
            MedicalRecord record = _medicalRecordService.GetMedicalRecord(jmbg);
            if(record != null)
            {
                return _medicalRecordDao.FindHealthCareByRecord(record.Id);
            }
            return null;
        }
        
      
        public void RemoveHealthCare(string jmbg)
        {
            MedicalRecord record = _medicalRecordService.GetMedicalRecord(jmbg);
            if(record != null)
            {
                _medicalRecordDao.RemoveHealthCareFromRecord(record.Id);
            }
        }
      
      
   
   }
}