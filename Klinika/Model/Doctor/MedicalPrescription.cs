// File:    MedicalPrescription.cs
// Created: Monday, April 6, 2020 7:28:37 PM
// Purpose: Definition of Class MedicalPrescription

using Klinika.Database;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class MedicalPrescription : IIdentifiable<long>
    {
        private string v;

        public long Id { set; get; }
        public string Note { set; get; }
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; } 
        public List<Diagnosis> Diagnosis { set; get; }

        public MedicalPrescription(long id)
        {
            Id = id;
        }

        public MedicalPrescription()
        {
        }

        public MedicalPrescription(string v)
        {
            this.v = v;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}