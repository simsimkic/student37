// File:    MedicalExaminationService.cs
// Created: Thursday, May 14, 2020 10:25:03 AM
// Purpose: Definition of Class DiagnosisService

using Dao.Documents;
using Dao.Documents.CSVImpl;
using Dto;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Service.Documents
{
   public class DiagnosisService
   {
        private readonly IDiagnosisDao _diagnosisDao;

        public DiagnosisService(IDiagnosisDao dao)
        {
            _diagnosisDao = dao;
        }

        public Diagnosis AddDiagnosis(Diagnosis diagnosis)
            => _diagnosisDao.Save(diagnosis);

        public List<Diagnosis> GetAllDiagnosis()
            => (List<Diagnosis>)_diagnosisDao.FindAll();

        public Diagnosis GetDiagnosis(long diagnosis)
              => _diagnosisDao.FindById(diagnosis);

    }
}