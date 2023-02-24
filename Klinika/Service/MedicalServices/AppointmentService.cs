// File:    AppointmentService.cs
// Created: Thursday, May 21, 2020 3:21:46 PM
// Purpose: Definition of Class AppointmentService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Dao.Users.CSVImpl;
using Klinika.Service.MedicalServices;
using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
   public class AppointmentService
   {
        private readonly IAppointmentDao _appointmentDao;
        private readonly IMedicalExaminationDao _medicalExaminationDao;
        private readonly IMedicalOperationDao _medicalOperationDao;

        public AppointmentService(IAppointmentDao appointmentDao, IMedicalExaminationDao medicalExaminationDao, IMedicalOperationDao medicalOperationDao)
        {
            _appointmentDao = appointmentDao;
            _medicalExaminationDao = medicalExaminationDao;
            _medicalOperationDao = medicalOperationDao;
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            _appointmentDao.Save(appointment);
            //if (appointment.Type == AppointmentType.examination)
            //{
            //    MedicalExamination examination = _medicalExaminationDao.FindById(appointment.MedicalExamination.Id);
            //    _medicalExaminationDao.Save(examination);
            //}
            //else
            //{
            //    MedicalOperation operation = _medicalOperationDao.FindById(appointment.MedicalOperation.Id);
            //    _medicalOperationDao.Save(operation);
            //}
        }
       
        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach(Appointment appointment in _appointmentDao.FindAll())
            {
                if (appointment.StartTime.Date == date.Date)
                    appointments.Add(appointment);
            }
            return appointments;
        }
      
      
      public List<Appointment> GetAppointmentsByType(AppointmentType type)
      {
            List<Appointment> typeAppointments = new List<Appointment>();
            foreach (Appointment appointment in _appointmentDao.FindAll())
            {
                if (appointment.Type.Equals(type))
                    typeAppointments.Add(appointment);
            }
            return typeAppointments;
        }
       
      public void CancelAppointment(long id)
      {
            _appointmentDao.DeleteById(id);
      }
      
     
   }
}