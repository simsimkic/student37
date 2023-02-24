// File:    DoctorsAppointmentsService.cs
// Created: Friday, May 29, 2020 1:57:06 PM
// Purpose: Definition of Class DoctorsAppointmentsService

using Dao.Employees.CSVImpl;
using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Dto;
using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using Service.Employees;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
   public class DoctorsAppointmentsService
   {
        private readonly IAppointmentDao _appointmentDao;
        private readonly WorkTimeService _workTime;

        public DoctorsAppointmentsService(IAppointmentDao appointmentDao, WorkTimeService workTime)
        {
            _appointmentDao = appointmentDao;
            _workTime = workTime;
        }

        public List<Appointment> generateDoctorExaminationAppointments(Doctor doctor,DateTime dateTime)
        {
            TermDTO term = _workTime.FindEmployeeWTByDate(doctor.WorkTime.Id, dateTime);
            
            Room room = new Room(doctor.Room.Id);
            List<Appointment> appointments = new List<Appointment>();
            if (term != null)
            {
                term.startDate = dateTime.Date.AddHours(term.startDate.Hour).AddMinutes(term.startDate.Minute);
                term.dueDate = dateTime.Date.AddHours(term.dueDate.Hour).AddMinutes(term.dueDate.Minute);
                
                while (DateTime.Compare(term.startDate,term.dueDate)<0)
                {
                    
                    appointments.Add(new Appointment(term.startDate, term.startDate.AddMinutes(30), room, doctor,AppointmentType.examination));
                    term.startDate=term.startDate.AddMinutes(30);
                }
            }
            return appointments;
        }

        public List<Appointment> generateDoctorOperationAppointments(Doctor doctor, DateTime dateTime)
        {
            TermDTO term = _workTime.FindEmployeeWTByDate(doctor.WorkTime.Id, dateTime);
            Room room = new Room();
            List<Appointment> appointments = new List<Appointment>();
            if (term != null)
            {
                term.startDate = dateTime.Date.AddHours(term.startDate.Hour).AddMinutes(term.startDate.Minute);
                term.dueDate = dateTime.Date.AddHours(term.dueDate.Hour).AddMinutes(term.dueDate.Minute);
                while (DateTime.Compare(term.startDate, term.dueDate) < 0)
                {
                    appointments.Add(new Appointment(term.startDate, term.startDate.AddMinutes(60), room, doctor, AppointmentType.operation));
                    term.startDate=term.startDate.AddMinutes(60);
                }
            }
            return appointments;
        }
        public List<Appointment> GetScheduledAppointmentsByDoctor(Doctor doctor)
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            foreach (Appointment appointment in _appointmentDao.FindAll())
            {
                if (appointment.Doctor.Jmbg.Equals(doctor.Jmbg))
                    doctorAppointments.Add(appointment);
            }
            return doctorAppointments;
        }
        public List<Appointment> getFreeDoctorExaminationAppointmentsByDate(Doctor doctor, DateTime date)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            foreach(Appointment appointment in generateDoctorExaminationAppointments(doctor, date))
            {
                if (isDoctorAppointmentFree(doctor, appointment))
                {
                    freeAppointments.Add(appointment);
                }
            }
            return freeAppointments;
         
        }

        public List<Appointment> getFreeDoctorOperationAppointmentsByDate(Doctor doctor, DateTime date)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            foreach (Appointment appointment in generateDoctorOperationAppointments(doctor, date))
            {
                if (isDoctorAppointmentFree(doctor, appointment))
                {
                    freeAppointments.Add(appointment);
                }
            }
            return freeAppointments;

        }



        public bool isDoctorAppointmentFree(Doctor doctor,Appointment isFreeAppointment)
        {
            foreach(Appointment appointment in GetScheduledAppointmentsByDoctor(doctor))
            {
                if((isFreeAppointment.StartTime.CompareTo(appointment.StartTime) >= 0 
                    && isFreeAppointment.StartTime.CompareTo(appointment.EndTime) < 0 )
                    || (isFreeAppointment.EndTime.CompareTo(appointment.StartTime) >= 0 
                    && isFreeAppointment.EndTime.CompareTo(appointment.EndTime) <= 0))
                {
                    return false;
                }
            }
            return true;
        }

      
      
     
   
   }
}