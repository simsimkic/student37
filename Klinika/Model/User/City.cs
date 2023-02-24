// File:    City.cs
// Created: Tuesday, April 7, 2020 4:26:24 PM
// Purpose: Definition of Class City

using System;

namespace Model.User
{
   public class City
   {
        public string Name { get; set; }

        public Municipality Municipality { get; set; }

        public City(string name)
        {
            Name = name;
        }
   
   }
}