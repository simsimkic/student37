// File:    MedicalTreatment.cs
// Created: Thursday, April 9, 2020 2:44:19 PM
// Purpose: Definition of Class MedicalTreatment

using Klinika.Database;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class MedicalTreatment : IIdentifiable<long>
    {
        private string v;

        public long Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public List<Diagnosis> Diagnosis { get; set; }

        public MedicalTreatment()
        {
        }

        public MedicalTreatment(long id)
        {
            Id = id;
        }

        public MedicalTreatment(string v)
        {
            this.v = v;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}