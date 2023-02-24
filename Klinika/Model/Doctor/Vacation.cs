// File:    Vacation.cs
// Created: Monday, April 6, 2020 7:17:49 PM
// Purpose: Definition of Class Vacation

using Klinika.Database;
using System;

namespace Model.Doctor
{
   public class Vacation : IIdentifiable<long>
    {
        public Doctor doctor { get; set; }
        public long Id { get; set; }
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }

        public Vacation(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Property for Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Doctor Doctor
      {
         get
         {
            return doctor;
         }
         set
         {
            if (this.doctor == null || !this.doctor.Equals(value))
            {
               if (this.doctor != null)
               {
                  Doctor oldDoctor = this.doctor;
                  this.doctor = null;
                  oldDoctor.RemoveVacation(this);
               }
               if (value != null)
               {
                  this.doctor = value;
                  this.doctor.AddVacation(this);
               }
            }
         }
      }

        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;
    }
}