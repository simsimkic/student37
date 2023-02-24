/***********************************************************************
 * Module:  RasporedOperacija.cs
 * Purpose: Definition of the Class RasporedOperacija
 ***********************************************************************/

using System;

namespace Model.Secretary
{
   public class Schedule
   {
      public System.Collections.ArrayList appointments;
      
      /// <summary>
      /// Property for collection of Appointment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Appointments
      {
         get
         {
            if (appointments == null)
               appointments = new System.Collections.ArrayList();
            return appointments;
         }
         set
         {
            RemoveAllAppointments();
            if (value != null)
            {
               foreach (Appointment oAppointment in value)
                  AddAppointments(oAppointment);
            }
         }
      }
      
      /// <summary>
      /// Add a new Appointment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAppointments(Appointment newAppointment)
      {
         if (newAppointment == null)
            return;
         if (this.appointments == null)
            this.appointments = new System.Collections.ArrayList();
         if (!this.appointments.Contains(newAppointment))
            this.appointments.Add(newAppointment);
      }
      
      /// <summary>
      /// Remove an existing Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAppointments(Appointment oldAppointment)
      {
         if (oldAppointment == null)
            return;
         if (this.appointments != null)
            if (this.appointments.Contains(oldAppointment))
               this.appointments.Remove(oldAppointment);
      }
      
      /// <summary>
      /// Remove all instances of Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAppointments()
      {
         if (appointments != null)
            appointments.Clear();
      }
   
   }
}