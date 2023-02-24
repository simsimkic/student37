// File:    MedicalExamination.cs
// Created: Monday, April 6, 2020 6:53:49 PM
// Purpose: Definition of Class MedicalExamination

using Klinika.Database;
using Model.Patient;
using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
    public class MedicalExamination : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string MainSimptoms { get; set; }
        public  string ObjectiveExamination { get; set; }
        public bool Status { get; set; } = false;
        public ReferralLetter ReferralLetter;
        public MedicalRecord MedicalRecord { get; set; }
        public Doctor Doctor { get; set; }
        public Appointment Appointment { get; set; }
        public List<Diagnosis> Diagnosis { get; set; }
        public MedicalPrescription MedicalPrescription { get; set; }
        public MedicalTreatment MedicalTreatment { get; set; }


        /// <summary>
        /// Property for Model.Patient.MedicalRecord
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
      
 

        public MedicalExamination(long id, string mainSymptoms, string objectiveExamination, bool status, ReferralLetter referralLetter,
            MedicalRecord medicalRecord, List<Diagnosis> diagnosis, Doctor doctor, Appointment appointment)
        {
            Id = id;
            MainSimptoms = mainSymptoms;
            ObjectiveExamination = objectiveExamination;
            Status = status;
            ReferralLetter = referralLetter;
            MedicalRecord = medicalRecord;
            Diagnosis = diagnosis;
            Doctor = doctor;
            Appointment = appointment;
        }

        public MedicalExamination() { }

        public MedicalExamination(long id)
        {
            Id = id;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public MedicalExamination(long id,String mainSimptoms,String objective,bool status,ReferralLetter referral,MedicalRecord medicalRecord,Doctor doctor,Appointment appointment)
        {
            Id = id;
            MainSimptoms = mainSimptoms;
            ObjectiveExamination = objective;
            Status = status;
            ReferralLetter = referral;
            MedicalRecord = medicalRecord;
            Doctor = doctor;
            Appointment = appointment;
        }

        public MedicalExamination(long id, string mainSimptoms, string objective, bool status, ReferralLetter referral, MedicalRecord medicalRecord, Doctor doctor, Appointment appointment, List<Diagnosis> diagnosis) : this(id, mainSimptoms, objective, status, referral, medicalRecord, doctor, appointment)
        {
            this.Diagnosis = diagnosis;
        }

        public MedicalExamination(long id, string mainSimptoms, string objective, bool status, ReferralLetter referral, MedicalRecord medicalRecord, Doctor doctor, Appointment appointment, List<Diagnosis> diagnosis, MedicalPrescription medicalPrescription, MedicalTreatment medicalTreatment) : this(id, mainSimptoms, objective, status, referral, medicalRecord, doctor, appointment, diagnosis)
        {
            this.MedicalPrescription = medicalPrescription;
            this.MedicalTreatment = medicalTreatment;
        }
    }
}