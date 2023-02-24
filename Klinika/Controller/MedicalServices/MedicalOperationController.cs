// File:    MedicalOperationController.cs
// Created: Friday, May 15, 2020 10:39:02 AM
// Purpose: Definition of Class MedicalOperationController

using Model.Doctor;
using Model.Patient;
using Model.Secretary;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class MedicalOperationController
   {
        private readonly MedicalOperationService _medicalOperationService;

        public MedicalOperationController(MedicalOperationService medicalOperationService)
        {
            _medicalOperationService = medicalOperationService;
        }
        public MedicalOperation SaveMedicalOperation(MedicalOperation operation)
            => _medicalOperationService.SaveMedicalOperation(operation);

        public List<MedicalOperation> GetAllMedicalOperations()
            => _medicalOperationService.GetAllMedicalOperations();

        public MedicalOperation GetOperationById(long id)
            => _medicalOperationService.GetOperationById(id);

        public void RemoveMedicalOperation(MedicalOperation operation)
            => _medicalOperationService.RemoveMedicalOperation(operation);
      
   
   }
}