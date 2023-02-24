// File:    AppointmentController.cs
// Created: Thursday, May 21, 2020 4:30:22 PM
// Purpose: Definition of Class AppointmentController

using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class AppointmentController
   {
        private readonly AppointmentService _appointmentService;
        public  AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public void ScheduleAppointment(Appointment appointment)
             => _appointmentService.ScheduleAppointment(appointment);

        public List<Appointment> GetAppointmentsByType(AppointmentType type)
       => _appointmentService.GetAppointmentsByType(type);

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        => _appointmentService.GetAppointmentsByDate(date);

        public void CancelAppointment(long id)
        => _appointmentService.CancelAppointment(id);
    
   
   }
}