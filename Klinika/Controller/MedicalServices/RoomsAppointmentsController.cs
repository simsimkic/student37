// File:    RoomsAppointmentsController.cs
// Created: Friday, May 29, 2020 2:46:06 PM
// Purpose: Definition of Class RoomsAppointmentsController

using Dto;
using Model.Manager;
using Model.Secretary;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class RoomsAppointmentsController
   {

        private readonly RoomsAppointmentsService roomsAppointmentsService;

        public RoomsAppointmentsController(RoomsAppointmentsService appointmentsService)
        {
            roomsAppointmentsService = appointmentsService;
        }


        public List<Appointment> GetScheduledAppointmentsByRoom(Room room)
            => roomsAppointmentsService.GetScheduledAppointmentsByRoom(room);

        public List<Appointment> getFreeRoomAppointmentsByDate(Room room, DateTime date)
            => roomsAppointmentsService.getFreeRoomAppointmentsByDate(room, date);
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
      
     
   
   }
}