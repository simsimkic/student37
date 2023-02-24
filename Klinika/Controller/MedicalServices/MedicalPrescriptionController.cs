// File:    MedicalPrescriptionController.cs
// Created: Thursday, May 28, 2020 9:22:21 AM
// Purpose: Definition of Class MedicalPrescriptionController

using Model.Doctor;
using Model.Patient;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Controller.MedicalServices
{
   public class MedicalPrescriptionController
   {
        public MedicalPrescriptionService medicalPrescriptionService = new MedicalPrescriptionService();

        public void SaveMedicalPrescription(MedicalPrescription prescription)
            => medicalPrescriptionService.SaveMedicalPrescription(prescription);

        public MedicalPrescription GetMedicalPrescrpiotion(long prescription)
            => medicalPrescriptionService.GetMedicalPrescription(prescription);

        public List<MedicalPrescription> GetAllMedicalPrescriptions()
              => medicalPrescriptionService.GetAllMedicalPrescriptions();

    }
}