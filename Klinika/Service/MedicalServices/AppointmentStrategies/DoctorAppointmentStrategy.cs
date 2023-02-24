using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Model.Doctor;
using Model.Secretary;
using Service.MedicalServices;

namespace Klinika.Service.MedicalServices.AppointmentStrategies
{
    public class DoctorAppointmentStrategy : IAppointmentStrategy
    {
        private readonly DoctorsAppointmentsService _doctorsAppointmentsService;

        public DoctorAppointmentStrategy(DoctorsAppointmentsService doctorsAppointmentsService)
        {
            _doctorsAppointmentsService = doctorsAppointmentsService;
        }


        public Appointment GetFreeAppointmentRecommendation(Doctor doctor, List<DateTime> dates)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            foreach (DateTime date in dates)
            {
                foreach(Appointment appointment 
                    in _doctorsAppointmentsService.getFreeDoctorExaminationAppointmentsByDate(doctor, date))
                {
                    if (!appointment.In24Hours)
                    {
                        freeAppointments.Add(appointment);
                    }
                }
                if (freeAppointments.Count > 0)
                {
                    return freeAppointments[0];
                }
                    
            }
            return null;
        }
    }
}
