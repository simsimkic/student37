// File:    MedicalOperationService.cs
// Created: Thursday, May 14, 2020 10:43:40 AM
// Purpose: Definition of Class MedicalOperationService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Model.Doctor;
using Model.Patient;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.MedicalServices
{
   public class MedicalOperationService
   {
        private readonly IMedicalOperationDao _medicalOperationDao;
        private readonly IAppointmentDao _appointmentDao;
        
        public MedicalOperationService(IMedicalOperationDao medicalOperationDao, IAppointmentDao appointmentDao)
        {
            _medicalOperationDao = medicalOperationDao;
            _appointmentDao = appointmentDao;
        }
      
      public MedicalOperation SaveMedicalOperation(MedicalOperation operation)
      {
            _medicalOperationDao.Save(operation);
            return operation;
      }
      
     public List<MedicalOperation> GetAllMedicalOperations()
        {
            return _medicalOperationDao.FindAll().ToList();
        }

     public MedicalOperation GetOperationById(long id)
        => _medicalOperationDao.FindById(id);
        
     public void RemoveMedicalOperation(MedicalOperation operation)
     {
           _medicalOperationDao.Delete(operation);
           Appointment appointment = _appointmentDao.FindById(operation.Appointment.Id);
           if (appointment != null)
           {
                _appointmentDao.Delete(appointment);
           }
     }   
   
   }
}