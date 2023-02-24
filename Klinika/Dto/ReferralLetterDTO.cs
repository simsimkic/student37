// File:    ReferralLetterDTO.cs
// Created: Wednesday, May 20, 2020 4:11:40 PM
// Purpose: Definition of Class ReferralLetterDTO

using System;

namespace Dto
{
   public class ReferralLetterDTO
   {
      private Model.Patient.Patient patient;
      private Model.Doctor.Doctor specialistDoctor;
      private Model.Doctor.Doctor writtenByDoctor;
      private Model.Doctor.ReferralLetter referralLetter;
   
   }
}