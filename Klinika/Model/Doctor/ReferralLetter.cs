// File:    ReferralLetter.cs
// Created: Monday, April 6, 2020 8:20:14 PM
// Purpose: Definition of Class ReferralLetter

using System;
using Model.Secretary;
using Klinika.Database;

namespace Model.Doctor
{
   public class ReferralLetter : IIdentifiable<long>
    {
        private string v;

        public long Id { get; set; }
        public string Note { get; set; }
        public MedicalExamination MedicalExamination { get; set; }  
        public MedicalOperation MedicalOperation { get; set; }      
        public Specialization Specialization { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public ReferralLetter(long id, string note, bool givenReferralLetter)
        {
        }

        public ReferralLetter(long id)
        {
            Id = id;
        }

        public ReferralLetter()
        {
        }

        public ReferralLetter(string v)
        {
            this.v = v;
        }
    }
}
