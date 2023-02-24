// File:    RenovationController.cs
// Created: Wednesday, May 27, 2020 7:00:41 PM
// Purpose: Definition of Class RenovationController

using Model.Manager;
using Service.Clinic;
using System;
using System.Collections.Generic;

namespace Controller.Clinic
{
   public class RenovationController
   {
        private readonly RenovationService _renovationService;

        public RenovationController(RenovationService service)
        {
            _renovationService = service;
        }

        public void AddReniovation(Renovation newRenovation)
          => _renovationService.AddRenovation(newRenovation);

        public void RemoveRenovation(long id)
          => _renovationService.RemoveRenovation(id);

        public Renovation GetRenovation(long id)
          => _renovationService.GetRenovation(id);

        public List<Renovation> GetAllRenovations()
          => _renovationService.GetAllRenovations();
   }
}