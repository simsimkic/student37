// File:    Specialist.cs
// Created: Thursday, May 28, 2020 12:19:03 PM
// Purpose: Definition of Class Specialist

using System;

namespace Model.Doctor
{
   public class Specialist : Doctor
    {
      
      public Specialization Specialization { get; set; }

      public Specialist(User.User user) : base(user) { }

        public Specialist(string jmbg) : base(jmbg)
        {
        }

        public Specialist()
        {
        }
    }
}

