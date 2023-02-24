// File:    RegisterUserDTO.cs
// Created: Wednesday, May 13, 2020 3:52:58 PM
// Purpose: Definition of Class RegisterUserDTO

using Model.Doctor;
using Model.Manager;
using Model.Patient;
using Model.User;
using System;
using System.Collections.Generic;

namespace Dto
{
   public class RegisterUserDTO
   {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public List<Role> Roles { get; set; }
        public Sex Sex { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Specialization Specialization { get; set; }
        public WorkTime WorkTime { get; set; }

        public RegisterUserDTO() { }

        public RegisterUserDTO(string name, string lastName, string jmbg, string username, string email,
            string phone, DateTime birthDate, Address address, List<Role> roles, Sex sex, MaritalStatus marital,
            Specialization spec, WorkTime wt)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Address = address;
            Roles = roles;
            Sex = sex;
            MaritalStatus = marital;
            Specialization = spec;
            WorkTime = wt;
        }
    }
}