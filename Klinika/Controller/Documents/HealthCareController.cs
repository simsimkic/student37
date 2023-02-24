// File:    HealthCareController.cs
// Created: Tuesday, May 26, 2020 7:44:36 PM
// Purpose: Definition of Class HealthCareController

using Model.Patient;
using Service.Documents;
using System;

namespace Controller.Documents
{
    public class HealthCareController
    {
        private readonly HealthCareService _healthCareService;

        public HealthCareController(HealthCareService healthCareService)
        {
            _healthCareService = healthCareService;
        }

        public HealthCare SetHealthCare(string jmbg, HealthCare healthCare)
            => _healthCareService.SetHealthCare(jmbg, healthCare);

        public HealthCare GetHealthCare(string jmbg)
            => _healthCareService.GetHealthCare(jmbg);

        public void RemoveHealthCare(string jmbg)
            => _healthCareService.RemoveHealthCare(jmbg);
    }
}