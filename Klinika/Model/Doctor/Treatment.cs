// File:    Treatment.cs
// Created: Thursday, April 9, 2020 2:44:19 PM
// Purpose: Definition of Class Treatment

using Klinika.Database;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class Treatment : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Treatment()
        {
        }

        public Treatment(long id)
        {
            Id = id;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}