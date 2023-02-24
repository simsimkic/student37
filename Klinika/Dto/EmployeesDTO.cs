// File:    EmployeesDTO.cs
// Created: Thursday, May 28, 2020 4:40:39 PM
// Purpose: Definition of Class EmployeesDTO

using Model.Doctor;
using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Dto
{
   public class EmployeesDTO
   {
      public List<Doctor> doctors { get; set; }
      public List<Secretary> secretaries { get; set; }

        public EmployeesDTO() { }
   
   }
}