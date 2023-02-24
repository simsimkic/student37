// File:    ReferralLetterService.cs
// Created: Thursday, May 14, 2020 10:56:34 AM
// Purpose: Definition of Class ReferralLetterService

using Dao.Documents;
using Dao.Documents.CSVImpl;
using Dto;
using Model.Doctor;
using Model.Patient;
using Service.MedicalServices;
using System;
using System.Collections.Generic;

namespace Service.Documents
{
    public class ReferralLetterService
    {
        private readonly IReferralLetterDao _referralLetterDao;
        private readonly PatientExaminationService _patientExaminationService;

        public ReferralLetterService(IReferralLetterDao referralLetterDao, PatientExaminationService patientExaminationService)
        {
            _referralLetterDao = referralLetterDao;
            _patientExaminationService = patientExaminationService;
        }

        public ReferralLetterService(IReferralLetterDao dao)
        {
            _referralLetterDao = dao;
        }

        public ReferralLetter AddReferralLetter(ReferralLetter referralLetter)
          => _referralLetterDao.Save(referralLetter);

        public List<ReferralLetter> GetPatientReferralLetters(Patient patient)
        {
            List<ReferralLetter> referralLetters = new List<ReferralLetter>();
            foreach(MedicalExamination examination 
                in _patientExaminationService.ListExaminationHistory(patient))
            {
                ReferralLetter letter = _referralLetterDao.FindById(examination.ReferralLetter.Id);
                if(letter != null)
                {
                    referralLetters.Add(letter);
                }
            }
            return referralLetters;
        }

    }
}