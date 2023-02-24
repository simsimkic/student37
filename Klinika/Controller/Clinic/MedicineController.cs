// File:    MedicineController.cs
// Created: Friday, May 15, 2020 9:54:37 PM
// Purpose: Definition of Class MedicineController

using Model.Manager;
using System;
using System.Collections.Generic;
using Model.Doctor;
using Service.Clinic;

namespace Controller.Clinic
{
   public class MedicineController
   {
        private readonly MedicineService _medicineService;

        public MedicineController(MedicineService service)
        {
            _medicineService = service;
        }

        public void SendForApproval(Medicine newMedicine)
          => _medicineService.SendForApproval(newMedicine);

        public void AddExistingMedicine(string medicineTag, int amount)
          => _medicineService.AddExistingMedicine(medicineTag, amount);

        public void RemoveMedicine(string medicineTag)
          => _medicineService.RemoveMedicine(medicineTag);

        public Medicine AddMedicine(Medicine medicine)
           => _medicineService.AddMedicine(medicine);

        public Medicine GetMedicine(string medicineTag)
          => _medicineService.GetMedicine(medicineTag);

        public List<Medicine> GetAllMedicines()
          => _medicineService.GetAllMedicines();

        public List<Medicine> IsAccepted(List<Medicine> medicines)
          => _medicineService.IsAccepted(medicines);

        public List<Medicine> GetAllMedicinesInProccess()
            => _medicineService.GetAllMedicinesInProccess();


        public List<Medicine> GetAllMedicinesByDiagnosis(List<Diagnosis> diagnosis)
            => _medicineService.GetAllMedicinesByDiagnosis(diagnosis);
      
      public List<Medicine> Search(List<string> words)
      {
         throw new NotImplementedException();
      }
      
      public List<Medicine> SearchByFilter(List<string> filters)
      {
         throw new NotImplementedException();
      }
   }
}