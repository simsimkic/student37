// File:    Doctor.cs
// Created: Monday, April 6, 2020 7:11:20 PM
// Purpose: Definition of Class Doctor

using Klinika.Database;
using Model.Manager;
using Model.Patient;
using System;
using System.Collections.Generic;
using Model.User;

namespace Model.Doctor
{
   public class Doctor : User.User, IIdentifiable<string>
    {

        public List<Question> Questions { get; set; }
        public WorkTime WorkTime { get; set; }      
        public Room Room { get; set; }
        public List<Vacation> Vacations { get; set; }

        //public Doctor(string jmbg) : base(jmbg) { }

        /// <summary>
        /// Property for collection of Vacation
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Vacation> Vacation
      {
         get
         {
            if (Vacations == null)
               Vacations = new System.Collections.Generic.List<Vacation>();
            return Vacations;
         }
         set
         {
            RemoveAllVacation();
            if (value != null)
            {
               foreach (Vacation oVacation in value)
                  AddVacation(oVacation);
            }
         }
      }
      
      /// <summary>
      /// Add a new Vacation in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddVacation(Vacation newVacation)
      {
         if (newVacation == null)
            return;
         if (this.Vacations == null)
            this.Vacations = new System.Collections.Generic.List<Vacation>();
         if (!this.Vacations.Contains(newVacation))
         {
            this.Vacations.Add(newVacation);
            newVacation.Doctor = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Vacation from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveVacation(Vacation oldVacation)
      {
         if (oldVacation == null)
            return;
         if (this.Vacations != null)
            if (this.Vacations.Contains(oldVacation))
            {
               this.Vacations.Remove(oldVacation);
               oldVacation.Doctor = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Vacation from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllVacation()
      {
         if (Vacations != null)
         {
            System.Collections.ArrayList tmpVacation = new System.Collections.ArrayList();
            foreach (Vacation oldVacation in Vacations)
               tmpVacation.Add(oldVacation);
            Vacations.Clear();
            foreach (Vacation oldVacation in tmpVacation)
               oldVacation.Doctor = null;
            tmpVacation.Clear();
         }
      }

        public string GetId()
        => Jmbg;

        public void SetId(string id)
        => Jmbg = id;

        public Doctor(User.User user) : base(user)
        {
            
        }

        public Doctor(string jmbg) : base(jmbg) { }

        public Doctor()
        {
        }

        public Doctor(User.User user, Room room, WorkTime workTime, List<Vacation> list1, List<Question> list2) : this(user)
        {
            this.Room = room;
            this.WorkTime = workTime;
            this.Vacations = list1;
            this.Questions = list2;
        }
    }
}