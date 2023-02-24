// File:    Appointment.cs
// Created: Saturday, April 11, 2020 1:33:31 PM
// Purpose: Definition of Class Appointment

using Model.Doctor;
using Model.Manager;
using System;

namespace Model.Secretary
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentType Type { get; set; }
        public Room Room { get; set; }
        public Doctor.Doctor Doctor { get; set; }
        public Patient.Patient Patient { get; set; }
       
        public MedicalExamination MedicalExamination { get; set; } = null;
        public MedicalOperation MedicalOperation { get; set; } = null;
        

        public Appointment(long id, DateTime startTime, DateTime endTime, AppointmentType type, Room room, Doctor.Doctor doctor,Patient.Patient patient)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            Room = room;
            Doctor = doctor;
            Patient = patient;
        }
        public Appointment() { }
   
        public bool isFree()
        {
            if (MedicalExamination == null && MedicalOperation == null && Patient==null)
                return true;
            return false;
        }

        public Appointment(string id)
        {
            Id = long.Parse(id);
        }
        public Appointment(DateTime start,DateTime end,Room room,Doctor.Doctor doctor,AppointmentType type)
        {
            StartTime = start;
            EndTime = end;
            Room = room;
            Doctor = doctor;
            Type = type;
        }

        public bool In24Hours
        {
            get
            {
                return DateTime.Now.AddHours(24).CompareTo(StartTime) == 1 ? true : false;
            }
        }
   }
}