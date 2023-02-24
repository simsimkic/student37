// File:    DoctorController.cs
// Created: Friday, May 15, 2020 10:14:35 AM
// Purpose: Definition of Class DoctorController

using Dto;
using Model.Doctor;
using Model.Secretary;
using Model.User;
using Service.Users;
using System;
using System.Collections.Generic;

namespace Controller.Users
{
   public class DoctorController
   {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public Doctor RegisterDoctor(RegisterUserDTO user)
            => _doctorService.Register(user);

        public Doctor LoginDoctor(string username, string password)
            => _doctorService.Login(username, password);

        public Doctor GetDoctor(string jmbg)
            => _doctorService.GetDoctor(jmbg);

        public List<Doctor> GetAllDoctors()
            => _doctorService.GetAllDoctors();
      
        public List<Doctor> GetOnDutyDoctors()
        {
             throw new NotImplementedException();
        }  
      
        public List<Doctor> GetFreeDoctorsByAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }


    }
}