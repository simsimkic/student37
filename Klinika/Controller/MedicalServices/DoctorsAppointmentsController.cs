// File:    DoctorsAppointmentsController.cs
// Created: Friday, May 29, 2020 1:57:06 PM
// Purpose: Definition of Class DoctorsAppointmentsController

using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class DoctorsAppointmentsController
        
   {
        DoctorsAppointmentsService _doctorsAppointments;
        public DoctorsAppointmentsController(DoctorsAppointmentsService doctorsAppointments)
        {
            _doctorsAppointments = doctorsAppointments;
        }
        public List<Appointment> GetScheduledAppointmentsByDoctor(Doctor doctor)
        => _doctorsAppointments.GetScheduledAppointmentsByDoctor(doctor);

        public List<Appointment> getFreeDoctorExaminationAppointmentsByDate(Doctor doctor, DateTime date)
            => _doctorsAppointments.getFreeDoctorExaminationAppointmentsByDate(doctor, date);

        public List<Appointment> getFreeDoctorOperationAppointmentsByDate(Doctor doctor, DateTime date)
            => _doctorsAppointments.getFreeDoctorOperationAppointmentsByDate(doctor, date);

        public bool isDoctorAppointmentFree(Doctor doctor, Appointment isFreeAppointment)
            => _doctorsAppointments.isDoctorAppointmentFree(doctor, isFreeAppointment);




   }
}