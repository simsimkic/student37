// File:    RoomsAppointmentsService.cs
// Created: Friday, May 29, 2020 2:46:06 PM
// Purpose: Definition of Class RoomsAppointmentsService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Dto;
using Model.Manager;
using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
   public class RoomsAppointmentsService
   {
        private readonly IAppointmentDao _appointmentDao;

        public RoomsAppointmentsService(IAppointmentDao appointmentDao)
        {
            _appointmentDao = appointmentDao;
        }

        public List<Appointment> generateRoomOperationAppointments(Room room, DateTime dateTime)
        {
            List<Appointment> appointments = new List<Appointment>();
            DateTime startDate = dateTime.Date;
            DateTime endDate = dateTime.Date.AddDays(1);
            while (DateTime.Compare(startDate, endDate) < 0)
            {
                DateTime endApp = startDate.AddHours(1);
                appointments.Add(new Appointment(startDate, endApp, room, null, AppointmentType.operation));
                startDate = startDate.AddHours(1);
            }
            return appointments;
        }
      
      public List<Appointment> GetScheduledAppointmentsByRoom(Room room)
      {
            List<Appointment> roomAppointments = new List<Appointment>();
            foreach (Appointment appointment in _appointmentDao.FindAll())
            {
                if (appointment.Room.Id.Equals(room.Id))
                    roomAppointments.Add(appointment);
            }
            return roomAppointments;
        }

        public bool isRoomAppointmentFree(Room room,Appointment isFreeAppointment)
        {
            foreach (Appointment appointment in GetScheduledAppointmentsByRoom(room))
            {
                if ((isFreeAppointment.StartTime.CompareTo(appointment.StartTime) >= 0
                   && isFreeAppointment.StartTime.CompareTo(appointment.EndTime) < 0)
                   || (isFreeAppointment.EndTime.CompareTo(appointment.StartTime) >= 0
                   && isFreeAppointment.EndTime.CompareTo(appointment.EndTime) <= 0))
                {
                    return false;
                }
            }
            return true;
        }

       public List<Appointment> getFreeRoomAppointmentsByDate(Room room,DateTime date)
       {
            List<Appointment> freeAppointments = new List<Appointment>();
            foreach (Appointment appointment in generateRoomOperationAppointments(room, date))
            {
                if (isRoomAppointmentFree(room, appointment))
                {
                    freeAppointments.Add(appointment);
                }
            }
            return freeAppointments;
        }

            public List<Appointment> FilterByRoom(string roomID)
      {
         throw new NotImplementedException();
      }
      
      public TermDTO FindSuggestionTerm(TermDTO term, List<DateTime> takenDates)
      {
         throw new NotImplementedException();
      }
      
      public List<DateTime> GenerateDates(List<Appointment> takenAppointments)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetRoomsByAppointments(List<Appointment> takenAppointments, List<Room> rooms)
      {
         throw new NotImplementedException();
      }
      
      public IAppointmentDao iAppointmentDao;
   
   }
}