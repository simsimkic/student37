// File:    EmployeeControler.cs
// Created: Thursday, May 28, 2020 5:03:33 PM
// Purpose: Definition of Class EmployeeControler

using Dto;
using Model.Doctor;
using Service.Users;
using System;
using System.Collections.Generic;

namespace Controller.Users
{
   public class EmployeeControler
   {
      public void AddEmployee(RegisterUserDTO newEmployee)
      {
            throw new NotImplementedException();
      }

      public void EditEmployee(RegisterUserDTO employee)
      {
         throw new NotImplementedException();
      }
      
      public void RemoveEmployee(string jmbg)
      {
         throw new NotImplementedException();
      }
      
      public Vacation SendOnVacation(string jmbg)
      {
         throw new NotImplementedException();
      }
      
      public EmployeesDTO GetAllEmployees()
      {
         throw new NotImplementedException();
      }
      
      public EmployeesDTO Search(List<string> words)
      {
         throw new NotImplementedException();
      }
      
      public EmployeesDTO SearchByFilter(List<string> filters)
      {
         throw new NotImplementedException();
      }
      
      public EmployeeService employeeService;
   
   }
}