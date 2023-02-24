// File:    Room.cs
// Created: Thursday, April 9, 2020 9:48:25 PM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using Model.Doctor;
using Model.Patient;

namespace Model.Manager
{
    public class Room
    {
        public string Id { get; set; }
        public int Floor { get; set; }
      
        public Renovation Renovation { get; set; }
        public List<Equipment> Equipment { get; set; }
        public Functionality Functionality { get; set; }
        public Department Department { get; set; }
        public Doctor.Doctor Doctor { get; set; }

        public Room() { }
        public Room(string id)
        {
            Id = id;
        }

        public Room(Room r)
        {
            Id = r.Id;
            Floor = r.Floor;
            Renovation = r.Renovation;
            Equipment = r.Equipment;
            Functionality = r.Functionality;
            Department = r.Department;
        }

        public Room(string id, int floor, Renovation renovation, List<Equipment> equipment,
            Functionality funct, Department dept)
        {
            Id = id;
            Floor = floor;
            Renovation = renovation;
            Equipment = equipment;
            Functionality = funct;
            Department = dept;
        }
    }
}