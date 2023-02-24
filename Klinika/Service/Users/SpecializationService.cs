// File:    SpecializatonService.cs
// Created: Thursday, May 28, 2020 12:41:22 PM
// Purpose: Definition of Class SpecializationService

using Dao.Users;
using Dao.Users.CSVImpl;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Service.Users
{
   public class SpecializationService
   {
        private readonly ISpecializationDao _specializationDao;

        public SpecializationService(ISpecializationDao dao)
        {
            _specializationDao = dao;
        }

        /*public List<Specialist> GetAllSpecialists(long specialization)
            => specializationDao.FindById(specialization).Specialists;*/

        public List<Specialization> GetAllSpecializations()
            => (List<Specialization>)_specializationDao.FindAll();

        public Specialization AddSpecialization(Specialization specialization)
            => _specializationDao.Save(specialization);

        public Specialization GetSpecializationByName(string specialization)
            => _specializationDao.FindByName(specialization);


    }
}