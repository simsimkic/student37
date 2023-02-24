// File:    AppointmentDao.cs
// Created: Wednesday, May 27, 2020 2:42:44 PM
// Purpose: Definition of Class AppointmentDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.MedicalServices;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Model.Doctor;
using Model.Manager;
using Model.Secretary;

namespace Dao.MedicalServices.CSVImpl
{
    public class AppointmentDao : IAppointmentDao
    {
        private readonly ICSVStream<Appointment> _stream;
        private readonly ISequencer<long> _sequencer;

       
        public AppointmentDao(ICSVStream<Appointment> stream, ISequencer<long> sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public AppointmentDao(ICSVStream<Appointment> stream)
        {
            _stream = stream;

        }

        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Appointment appointment) => DeleteById(appointment.Id);

        public void DeleteAll() => _stream.SaveAll(new List<Appointment>());

        public void DeleteById(long id)
        {
            List<Appointment> appointments = _stream.ReadAll().ToList();
            Appointment toRemove = appointments.SingleOrDefault(a => a.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                appointments.Remove(toRemove);
                _stream.SaveAll(appointments);
            }
            else
            {
                Console.WriteLine("Termin nije pronadjen");
            }
        }

        public bool ExistsById(long id) => FindById(id) == null ? false : true;

        public IEnumerable<Appointment> FindAll() => _stream.ReadAll().ToList();

        public List<Appointment> FindAppointmentsByWorkTime(Doctor doctor, WorkTime workTime, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment FindById(long id) 
            => FindAll().SingleOrDefault(a => a.Id.CompareTo(id) == 0);

        public List<Appointment> FindRoomsAppointmentsByWorkTime(Doctor doctor, WorkTime workTime, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment Save(Appointment newAppointment)
        {
            List<Appointment> appointments = _stream.ReadAll().ToList();
            Appointment appointment = appointments.SingleOrDefault(a => a.Id.CompareTo(newAppointment.Id) == 0);
            if (appointment != null)
            {
                appointments[appointments.FindIndex(a => a.Id.CompareTo(appointment.Id) == 0)] = newAppointment;
                _stream.SaveAll(appointments);
            }
            else
            {
                newAppointment.Id = _sequencer.GenerateId();
                _stream.AppendToFile(newAppointment);
            }
            return newAppointment;
        }

        public void SaveAll(IEnumerable<Appointment> newAppointments)
        {
            foreach(Appointment appointment in newAppointments)
            {
                Save(appointment);
            }
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private long GetMaxId(IEnumerable<Appointment> appointments)
        {
            return appointments.Count() == 0 ? 0 : appointments.Max(appointment => appointment.Id);
        }

        public IEnumerable<Appointment> FindByDoctorId(string id)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach(Appointment a in FindAll())
            {
                if(a.Doctor.Jmbg.CompareTo(id) == 0)
                {
                    appointments.Add(a);
                }
            }
            return appointments;
        }
        
    }
}