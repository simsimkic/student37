// File:    SpecialiyationController.cs
// Created: Thursday, May 28, 2020 12:41:22 PM
// Purpose: Definition of Class SpecializationController

using Model.Doctor;
using Service.Users;
using System;
using System.Collections.Generic;

namespace Controller.Users
{
   public class SpecialistController
   {
        private readonly SpecialistService _specialistService;

        public SpecialistController(SpecialistService service)
        {
            _specialistService = service;
        }

        public Specialist GetSpecialist(string jmbg)
            => _specialistService.GetSpecialist(jmbg);

        public List<Specialist> GetAllSpecialists()
            => _specialistService.GetAllSpecialists();

        public List<Specialist> GetSpecialistBySpeicalization(Specialization specialization)
            => _specialistService.GetSpecialistBySpeicalization(specialization);
    }
}