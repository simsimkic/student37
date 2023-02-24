// File:    MedicalRecord.cs
// Created: Monday, April 6, 2020 4:53:17 PM
// Purpose: Definition of Class MedicalRecord

using Model.Doctor;
using Model.Manager;
using System.Collections.Generic;

namespace Model.Patient
{
    public class MedicalRecord
    {
        private string v;

        public long Id { get; set; }
        public string HealthCardId { get; set; }
        public string Warning { get; set; }

        public HealthCare HealthCare { get; set; }
        public List<Employment> Employments { get; set; }
        public List<Ingredient> Allergies { get; set; }
        public List<Diagnosis> PastIllnesses { get; set; }
        public List<MedicalExamination> Examinations { get; set; }

        public MedicalRecord() { }

        public MedicalRecord(long id, string healthCardId, string warning, HealthCare healthCare, List<Employment> employments, 
                List<Ingredient> allergies, List<Diagnosis> pastIllnesses, List<MedicalExamination> examinations)
        {
            Id = id;
            HealthCardId = healthCardId;
            Warning = warning;
            HealthCare = healthCare;
            Employments = employments;
            Allergies = allergies;
            PastIllnesses = pastIllnesses;
            Examinations = examinations;
        }

        public MedicalRecord(long id)
        {
            Id = id;
        }

        public MedicalRecord(string v)
        {
            this.v = v;
        }
    }
}