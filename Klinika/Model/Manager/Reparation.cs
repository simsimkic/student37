// File:    Reparation.cs
// Created: Friday, April 17, 2020 8:16:05 PM
// Purpose: Definition of Class Reparation

using System;

namespace Model.Manager
{
   public class Reparation
   {
      public DateTime beginDate { get; set; }

        public Reparation() { }

        public Reparation(DateTime dt)
        {
            beginDate = dt;
        }
   }
}