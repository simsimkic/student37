// File:    PatientExaminationService.cs
// Created: Wednesday, May 13, 2020 5:14:42 PM
// Purpose: Definition of Class PatientExaminationService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Dto;
using Model.Doctor;
using Model.Patient;
using Model.Secretary;
using Service.Documents;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
    public class PatientExaminationService
    {
        private readonly IAppointmentDao _appointmentDao;
        private readonly IMedicalExaminationDao _medicalExaminationDao;
        private readonly MedicalRecordService _medicalRecordService;
        public PatientExaminationService(IAppointmentDao appointmentDao, IMedicalExaminationDao medicalExaminationDao, MedicalRecordService medicalRecordService)
        {
            _appointmentDao = appointmentDao;
            _medicalExaminationDao = medicalExaminationDao;
            _medicalRecordService = medicalRecordService;
        }
        public List<Appointment> ListUpcomingExaminations(Patient patient)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach(Appointment a in _appointmentDao.FindAll())
            {
                if (a.Patient.Jmbg.Equals(patient.Jmbg) && a.Type == AppointmentType.examination)
                {
                    appointments.Add(a);
                }
            }
            return appointments;
        }
      
        public List<MedicalExamination> ListExaminationHistory(Patient patient)
        {
            List<MedicalExamination> examinations = new List<MedicalExamination>();
            MedicalRecord record = _medicalRecordService.GetMedicalRecord(patient);
            if(record != null)
            {
                foreach (MedicalExamination examination
                in record.Examinations)
                {
                    examinations.Add(_medicalExaminationDao.FindById(examination.Id));
                }
                return examinations;
            }
            return null;
        }
   
    }
}