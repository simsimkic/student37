// File:    MedicalOperationDTO.cs
// Created: Wednesday, May 20, 2020 4:41:27 PM
// Purpose: Definition of Class MedicalOperationDTO

using System;

namespace Dto
{
   public class MedicalOperationDTO : MedicalExaminationToSpecialistDTO
   {
      private Model.Manager.RecoveryRoom recoveryRoom;
      private Model.Secretary.MedicalOperation operation;
   
   }
}