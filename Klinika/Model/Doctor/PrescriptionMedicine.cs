// File:    PrescriptionMedicine.cs
// Created: Monday, June 15, 2020 1:36:36 PM
// Purpose: Definition of Class PrescriptionMedicine

using System;
using Model.Manager;
using System.Collections.Generic;
using Klinika.Database;

namespace Model.Doctor
{
   public class PrescriptionMedicine : IIdentifiable<long>
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public Medicine Medicine { get; set; }

        public PrescriptionMedicine(long id)
        {
            Id = id;
        }

        public PrescriptionMedicine()
        {
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}