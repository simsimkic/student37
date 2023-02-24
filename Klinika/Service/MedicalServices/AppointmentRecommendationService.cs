using Dao.MedicalServices.CSVImpl;
using Klinika.Database.Csv.Stream;
using Klinika.Service.MedicalServices.AppointmentStrategies;
using Model.Doctor;
using Model.Secretary;
using Service.Employees;
using Service.MedicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Service.MedicalServices
{
    public class AppointmentRecommendationService
    {
        private IAppointmentStrategy _strategy;
        private readonly IAppointmentStrategy _doctorsAppointmentStrategy;
        private readonly IAppointmentStrategy _dateAppointmentStrategy;

        public AppointmentRecommendationService(IAppointmentStrategy doctorsAppointmentStrategy, IAppointmentStrategy dateAppointmentStrategy)
        {
            _doctorsAppointmentStrategy = doctorsAppointmentStrategy;
            _dateAppointmentStrategy = dateAppointmentStrategy;
        }
        public void ChooseStrategy(bool priority)
        {
            if (priority)
                _strategy = _doctorsAppointmentStrategy;
            else
                _strategy = _dateAppointmentStrategy;
        }
        public Appointment GetFreeAppointmentRecommendation(bool priority, Doctor doctor, List<DateTime> dates)
        {
            ChooseStrategy(priority);
            return _strategy.GetFreeAppointmentRecommendation(doctor, dates);
        }
    }
}
