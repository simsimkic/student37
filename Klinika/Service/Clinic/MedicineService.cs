// File:    MedicineService.cs
// Created: Friday, May 15, 2020 9:54:37 PM
// Purpose: Definition of Class MedicineService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Dao.Documents;
using Model.Doctor;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Service.Clinic
{
   public class MedicineService
   {
        private readonly IMedicineDao _medicineDao;
        private readonly IngredientService _ingredientService;
        private readonly IDiagnosisDao _diagnosisDao;

        public MedicineService(IMedicineDao medDao) {
            _medicineDao = medDao;
        }

        public MedicineService(IMedicineDao medDao, IngredientService ingService)
        {
            _medicineDao = medDao;
            _ingredientService = ingService;
        }

        //TODO Lek: Svim lekarima saljem lek
        public void SendForApproval(Medicine newMedicine)
        {
            _medicineDao.Save(newMedicine);
        }
      
      public void AddExistingMedicine(string medicineTag, int amount)
      {
            Medicine m = GetMedicine(medicineTag);
            m.Amount += amount;
            _medicineDao.Save(m);
      }

        public void RemoveMedicine(string medicineTag)
              => _medicineDao.DeleteById(medicineTag);

        public Medicine AddMedicine(Medicine medicine)
            => _medicineDao.Save(medicine);

        public Medicine GetMedicine(string medicineTag)
              => _medicineDao.FindById(medicineTag);

        public List<Medicine> GetAllMedicines()
              => (List<Medicine>) _medicineDao.FindAll();

        public List<Medicine> GetAllMedicinesInProccess()
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach (Medicine med in _medicineDao.FindAll()) {
                if (med.Validation == Valid.processing) {
                    medicines.Add(med);
                }
            }

            return medicines;
        }

        public List<Medicine> GetAllMedicinesByDiagnosis(List<Diagnosis> diagnosis)
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach (Medicine med in _medicineDao.FindAll()) {
                if (med.Validation == Valid.accepted) {
                    foreach (Diagnosis diag in diagnosis) {
                        if (diag.Equals(med.Diagnosis)) {
                            medicines.Add(med);
                        }
                    }
                }
            }

            return medicines;
        }



        public List<Medicine> IsAccepted(List<Medicine> medicines)
      {
          throw new NotImplementedException();
      }

      

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