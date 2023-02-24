// File:    Patient.cs
// Created: Monday, April 6, 2020 4:34:37 PM
// Purpose: Definition of Class Patient

using System;
using System.Collections.Generic;

namespace Model.Patient
{
    public class Patient : User.User
    {
        public Sex Sex { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public List<Question> Questions { get; set; }
        public Doctor.Doctor PrefferedDoctor { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public Patient(User.User user) : base(user) { }
        public Patient(User.User user, Sex sex, MaritalStatus maritalStatus, List<Question> questions, 
            Doctor.Doctor prefferedDoctor, MedicalRecord medicalRecord) : base(user)
        {
            Sex = sex;
            MaritalStatus = maritalStatus;
            Questions = questions;
            PrefferedDoctor = prefferedDoctor;
            MedicalRecord = medicalRecord;
        }
        public Patient(string jmbg, Sex sex, MaritalStatus maritalStatus, List<Question> questions,
            Doctor.Doctor prefferedDoctor, MedicalRecord medicalRecord) : base(jmbg)
        {
            Sex = sex;
            MaritalStatus = maritalStatus;
            Questions = questions;
            PrefferedDoctor = prefferedDoctor;
            MedicalRecord = medicalRecord;
        }
        public Patient(string jmbg) : base(jmbg) { }
    }
}