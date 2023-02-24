// File:    MedicalPrescriptionService.cs
// Created: Thursday, May 28, 2020 9:22:21 AM
// Purpose: Definition of Class MedicalPrescriptionService

using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using Model.Doctor;
using Model.Patient;
using System;
using System.Collections.Generic;

namespace Service.MedicalServices
{
   public class MedicalPrescriptionService
   {
        public IMedicalPrescriptionDao medicalPrescriptionDao = new MedicalPrescriptionDao();

        public void SaveMedicalPrescription(MedicalPrescription prescription)
            => medicalPrescriptionDao.Save(prescription);

        public MedicalPrescription GetMedicalPrescription(long prescription)
            => medicalPrescriptionDao.FindById(prescription);

        public List<MedicalPrescription> GetAllMedicalPrescriptions()
            => (List<MedicalPrescription>) medicalPrescriptionDao.FindAll();



    }
}