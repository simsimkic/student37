// File:    DoctorService.cs
// Created: Thursday, May 14, 2020 10:15:52 AM
// Purpose: Definition of Class DoctorService

using Dao.Employees;
using Dao.Employees.CSVImpl;
using Dao.Users;
using Dao.Users.CSVImpl;
using Dto;
using Model.Doctor;
using Model.Patient;
using Model.Manager;
using Model.User;
using Service.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using Model.Secretary;
using Klinika.Service.Users;
using Klinika.Dao.Users;

namespace Service.Users
{
   public class DoctorService : AbstractUserService<Doctor>
   {
        private readonly IDoctorDao _doctorDao;
        public DoctorService(IDoctorDao doctorDao, UserValidationService userValidationService, 
            AddressService addressService, IUserDao userDao, IAccountDao accountDao)
            : base(userValidationService, addressService, userDao, accountDao)
        {
            _doctorDao = doctorDao;
        }

        public Doctor GetDoctor(string jmbg)
            => GetUserById(jmbg);

        public List<Doctor> GetFreeDoctorsByAppointment(Appointment appointment)    
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
            =>(List<Doctor>) _doctorDao.FindAll();
      
        public List<Doctor> GetOnDutyDoctors()      
        {
            throw new NotImplementedException();
        }


        protected override Doctor RegisterRoleData(RegisterUserDTO user)    
        {
            User newUser = new User(user.Jmbg, user.Name, user.LastName, user.Username, user.Email, user.Phone, user.BirthDate, user.Roles, user.Address);
            Doctor doctor = new Doctor(newUser, new Room(), new WorkTime(), new List<Vacation>(), new List<Question>());
            _doctorDao.Save(doctor);

            return doctor;
        }

        protected override Doctor GetRoleData(User user)  
        {
            Doctor doctor = _doctorDao.FindById(user.Jmbg);

            return new Doctor(user, doctor.Room, doctor.WorkTime, doctor.Vacations, doctor.Questions);
        }

        protected override void DeleteFromRoleTable(string jmbg)       
            => _doctorDao.DeleteById(jmbg);



    }
}