// File:    User.cs
// Created: Monday, April 6, 2020 4:31:09 PM
// Purpose: Definition of Class User

using System;
using System.Collections.Generic;

namespace Model.User
{
   public class User
   {
        public User(User user)
        {
            Name = user.Name;
            LastName = user.LastName;
            Jmbg = user.Jmbg;
            Username = user.Username;
            Email = user.Email;
            Phone = user.Phone;
            BirthDate = user.BirthDate;
            Roles = user.Roles;
            Address = user.Address;
        }
        public User(string jmbg)
        {
            Jmbg = jmbg;
        }
        public User(string jmbg, string name, string lastName, string username, string email, string phone, DateTime birthDate, List<Role> roles, Address address)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Username = username;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Roles = roles;
            Address = address;
        }

        public User() { }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Role> Roles { get; set; }
        public Address Address { get; set; }

    }
}