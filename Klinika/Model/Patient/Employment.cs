// File:    Employment.cs
// Created: Tuesday, April 7, 2020 4:55:49 PM
// Purpose: Definition of Class Employment

using Klinika.Database;
using System;

namespace Model.Patient
{
   public class Employment : IIdentifiable<long>
   {
        public Employment(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
        public string Our { get; set; }
        public string Location { get; set; }
        public string RegistryNumber { get; set; }
        public string JobId { get; set; }
        public string Job { get; set; }
        public string Osiz { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}