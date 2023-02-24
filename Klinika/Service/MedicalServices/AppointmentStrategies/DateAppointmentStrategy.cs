using Dao.Users;
using Dao.Users.CSVImpl;
using Model.Doctor;
using Model.Secretary;
using Service.Employees;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Klinika.Service.MedicalServices.AppointmentStrategies
{
    public class DateAppointmentStrategy : IAppointmentStrategy
    {
        private readonly IDoctorDao _doctorDao;
        private readonly DoctorsAppointmentsService _doctorsAppointmentsService;
        private readonly WorkTimeService _workTimeService;
        public DateAppointmentStrategy(IDoctorDao doctorDao, DoctorsAppointmentsService doctorsAppointmentsService, WorkTimeService workTimeService)
        {
            _doctorDao = doctorDao;
            _doctorsAppointmentsService = doctorsAppointmentsService;
            _workTimeService = workTimeService;
        }
        public Appointment GetFreeAppointmentRecommendation(Doctor doctor, List<DateTime> dates)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            foreach (DateTime date in dates)
            {
                foreach (Appointment appointment
                    in _doctorsAppointmentsService.getFreeDoctorExaminationAppointmentsByDate(doctor, date))
                {
                    if (!appointment.In24Hours)
                    {
                        freeAppointments.Add(appointment);
                    }
                }
                if (freeAppointments.Count == 0)
                {
                    freeAppointments = findAlternatives(date);
                }
                if (freeAppointments.Count > 0)
                {
                    return freeAppointments[0];
                }
            }
            return null;
        }

        private List<Appointment> findAlternatives(DateTime date)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            foreach (Doctor doctor in _doctorDao.FindAll())
            {
                doctor.WorkTime = _workTimeService.GetWorkTime(doctor.WorkTime.Id);
                if (doctor.WorkTime == null) return freeAppointments;
                foreach (Appointment appointment
                    in _doctorsAppointmentsService.getFreeDoctorExaminationAppointmentsByDate(doctor, date))
                {
                    if (!appointment.In24Hours)
                    {
                        freeAppointments.Add(appointment);
                    }
                }
            }
            return freeAppointments;
        }
    }
}
