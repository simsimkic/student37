// File:    MedicalExaminationToSpecialistDTO.cs
// Created: Wednesday, May 20, 2020 4:35:19 PM
// Purpose: Definition of Class MedicalExaminationToSpecialistDTO

using System;

namespace Dto
{
   public class MedicalExaminationToSpecialistDTO : ReferralLetterDTO
   {
      private Model.Secretary.Appointment appointment;
      private Model.Manager.Room room;
      private Model.Doctor.MedicalExamination specExamination;
   
   }
}