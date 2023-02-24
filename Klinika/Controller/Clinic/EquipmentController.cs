// File:    EquipmentController.cs
// Created: Saturday, May 30, 2020 2:58:49 AM
// Purpose: Definition of Class EquipmentController

using Model.Manager;
using Service.Clinic;
using System;
using System.Collections.Generic;

namespace Controller.Clinic
{
   public class EquipmentController
   {
        private readonly EquipmentService _equipmentService;

        public EquipmentController(EquipmentService service)
        {
            _equipmentService = service;
        }
        public void AddEquipment(Equipment newEquipment)
            => _equipmentService.AddEquipment(newEquipment);
      
        public void EditEquipment(Equipment equipment)
            => _equipmentService.EditEquipment(equipment);
      
        public void RemoveEquipment(string equipmentID)
            => _equipmentService.RemoveEquipment(equipmentID);
      
        public Equipment GetEquipment(string equipmentID)
            => _equipmentService.GetEquipment(equipmentID);
      
        public List<Equipment> GetAllEquipment()
            => _equipmentService.GetAllEquipment();
      
      public void ScheduleReparation(List<string> iDs)
      {
         throw new NotImplementedException();
      }
      
      public void RetriveReraired(string equipmentID)
      {
         throw new NotImplementedException();
      }
      
        public List<Equipment> Search(List<string> words)
            => _equipmentService.Search(words);
      
        public List<Equipment> SearchByFilter(List<string> filters)
            => _equipmentService.SearchByFilter(filters);
   }
}