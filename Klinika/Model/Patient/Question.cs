// File:    Question.cs
// Created: Tuesday, April 21, 2020 12:26:52 PM
// Purpose: Definition of Class Question

using Klinika.Database;
using Model.Doctor;
using System;

namespace Model.Patient
{
   public class Question : IIdentifiable<long>
   {
        public Question(long id)
        {
            Id = id;
        }

        public Question(long id, string title, string content, Doctor.Doctor doctor) : this(id)
        {
            Title = title;
            Content = content;
            Doctor = doctor;
        }

        public Question(long id, string title, string content, string answer, bool isPublic, Doctor.Doctor doctor) 
            : this(id, title, content, doctor)
        {
            Answer = answer;
            IsPublic = isPublic;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; } = null;
        public bool IsPublic { get; set; } = false;
        public Doctor.Doctor Doctor { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}