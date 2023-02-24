// File:    MedicalExaminationService.cs
// Created: Thursday, May 14, 2020 10:25:03 AM
// Purpose: Definition of Class MedicalExaminationService

using Dao.Documents;
using Dao.Documents.CSVImpl;
using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Dto;
using Model.Doctor;
using Model.Patient;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.MedicalServices
{
   public class MedicalExaminationService
   {
        private readonly IMedicalExaminationDao _medicalExaminationDao;
        private readonly IMedicalRecordDao _medicalRecordDao;
        private readonly IAppointmentDao _appointmentDao;

        public MedicalExaminationService(IMedicalExaminationDao medicalExaminationDao, IMedicalRecordDao medicalRecordDao, IAppointmentDao appointmentDao)
        {
            _medicalExaminationDao = medicalExaminationDao;
            _medicalRecordDao = medicalRecordDao;
            _appointmentDao = appointmentDao;
        }
        public MedicalExamination SaveMedicalExamination(MedicalExamination examination)
        {
            MedicalRecord record = _medicalRecordDao.FindById(examination.MedicalRecord.Id);
            record.Examinations.Add(examination);
            _medicalRecordDao.Save(record);
            return _medicalExaminationDao.Save(examination);
        }

        public void RemoveMedicalExamination(MedicalExamination examination)
        {
            _medicalExaminationDao.Delete(examination);
            Appointment appointment = _appointmentDao.FindById(examination.Appointment.Id);
            if (appointment != null)
            {
                _appointmentDao.Delete(appointment);
            }
        }
        
      
    
   }
}