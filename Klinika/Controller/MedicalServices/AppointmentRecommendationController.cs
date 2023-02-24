using Klinika.Service.MedicalServices;
using Model.Doctor;
using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Klinika.Controller.MedicalServices
{
    public class AppointmentRecommendationController
    {
        private readonly AppointmentRecommendationService _appointmentRecommendationService;

        public AppointmentRecommendationController(AppointmentRecommendationService appointmentRecommendationService)
        {
            _appointmentRecommendationService = appointmentRecommendationService;
        }
        public Appointment GetFreeAppointmentRecommendation(bool priority, Doctor doctor, List<DateTime> dates)
            => _appointmentRecommendationService.GetFreeAppointmentRecommendation(priority, doctor, dates);
    }
}
