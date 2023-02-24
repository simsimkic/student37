// File:    EmployeeService.cs
// Created: Thursday, May 28, 2020 4:24:53 PM
// Purpose: Definition of Class EmployeeService

using Dto;
using Model.Doctor;
using Model.Manager;
using Model.Patient;
using Model.Secretary;
using Model.User;
using System;
using System.Collections.Generic;

namespace Service.Users
{
   public class EmployeeService
   {
        private readonly SecretaryService _secretaryService;
        private readonly DoctorService _doctorService;

        public EmployeeService(SecretaryService secretaryService, DoctorService doctorService)
        {
            _secretaryService = secretaryService;
            _doctorService = doctorService;
        }
        public void AddEmployee(RegisterUserDTO newEmployee)
      {
            if (newEmployee.Roles.Contains(Role.secretary))
                _secretaryService.Register(newEmployee);
            else if (newEmployee.Roles.Contains(Role.doctor))
                _doctorService.Register(newEmployee);
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

      public RegisterUserDTO GetEmployee(string jmbg)
      {
            Secretary s = _secretaryService.GetSecretary(jmbg);
            
            Doctor d = _doctorService.GetDoctor(jmbg);
            if (s != null)
                return new RegisterUserDTO(s.Name, s.LastName, s.Jmbg, s.Username, s.Username, s.Phone, s.BirthDate,
                    s.Address, s.Roles, s.Sex, s.MaritalStatus, new Specialization(), new WorkTime());
            if(d != null)
                return new RegisterUserDTO(d.Name, d.LastName, d.Jmbg, d.Username, d.Username, d.Phone, d.BirthDate,
                    d.Address, d.Roles, new Sex(), new MaritalStatus(), new Specialization(), d.WorkTime);
            return new RegisterUserDTO();
        }
      
      public EmployeesDTO GetAllEmployees()
      {
            EmployeesDTO allEmployees = new EmployeesDTO();
            allEmployees.doctors = _doctorService.GetAllDoctors();
            allEmployees.secretaries = _secretaryService.GetAllSecretaries();
            return allEmployees;
      }
      
      public EmployeesDTO Search(List<string> words)
      {
         throw new NotImplementedException();
      }
      
      public EmployeesDTO SearchByFilter(List<string> filters)
      {
         throw new NotImplementedException();
      }
      
      
   
   }
}