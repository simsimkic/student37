// File:    SpecialiyationController.cs
// Created: Thursday, May 28, 2020 12:41:22 PM
// Purpose: Definition of Class SpecializationController

using Model.Doctor;
using Service.Users;
using System;
using System.Collections.Generic;

namespace Controller.Users
{
   public class SpecializationController
   {
        private readonly SpecializationService _specializationService;

        public SpecializationController(SpecializationService service)
        {
            _specializationService = service;
        }

        /*public List<Specialist> GetAllSpecialists(long specialization)
            => specializationService.GetAllSpecialists(specialization);*/

        public List<Specialization> GetAllSpecializations()
            => _specializationService.GetAllSpecializations();

        public Specialization AddSpecialization(Specialization specialization)
            => _specializationService.AddSpecialization(specialization);

        public Specialization GetSpecializationByName(string specialization)
            => _specializationService.GetSpecializationByName(specialization);

    }
}