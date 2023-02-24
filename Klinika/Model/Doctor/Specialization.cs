// File:    Specialization.cs
// Created: Thursday, May 14, 2020 11:21:13 AM
// Purpose: Definition of Class Specialization

using Klinika.Database;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class Specialization : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }


        public Specialization() { }

        public Specialization(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


        public Specialization(long id)
        {
            Id = id;
        }
     

        public long GetId()
         => Id;

        public void SetId(long id)
         => Id = id;
    }
}



