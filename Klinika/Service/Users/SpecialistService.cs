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
   public class SpecialistService 
   {
        private readonly ISpecialistDao _specialistDao;
        private readonly SpecializationService specializationService;

        public SpecialistService(ISpecialistDao dao)
        {
            _specialistDao = dao;
        }

        public Specialist GetSpecialist(string jmbg)
            => _specialistDao.FindById(jmbg);

        public List<Specialist> GetAllSpecialists()
            =>(List<Specialist>) _specialistDao.FindAll();

        public List<Specialist> GetSpecialistBySpeicalization(Specialization specialization) {
            List<Specialist> specialists = new List<Specialist>();
            foreach (Specialist spec in _specialistDao.FindAll()) {
                if (spec.Specialization.Id == specialization.Id)
                {
                    specialists.Add(spec);
                }
            }

            return specialists;
        }
          

    }
}