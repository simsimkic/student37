// File:    ReferralLetterController.cs
// Created: Friday, May 15, 2020 10:35:21 AM
// Purpose: Definition of Class ReferralLetterController

using Dto;
using Model.Doctor;
using Service.Documents;
using System;

namespace Controller.Documents
{
   public class ReferralLetterController
   {
        private readonly ReferralLetterService _referralLetterService;

        public ReferralLetterController(ReferralLetterService service)
        {
            _referralLetterService = service;
        }

        public ReferralLetter AddReferralLetter(ReferralLetter referralLetter)
           => _referralLetterService.AddReferralLetter(referralLetter);


    }
}