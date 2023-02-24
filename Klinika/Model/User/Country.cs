// File:    Country.cs
// Created: Tuesday, April 7, 2020 4:26:25 PM
// Purpose: Definition of Class Country

using System;

namespace Model.User
{
   public class Country
   {
        public string Name { get; set; }

        public Country(string name)
        {
            Name = name;
        }
   }
}