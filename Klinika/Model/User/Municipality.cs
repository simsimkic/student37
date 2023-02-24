// File:    Municipality.cs
// Created: Tuesday, April 7, 2020 4:48:32 PM
// Purpose: Definition of Class Municipality

using System;

namespace Model.User
{
   public class Municipality
   {
      public string Name { get; set; }
      public Country Country { get; set; }

        public Municipality(string name)
        {
            Name = name;
        }
   }
}