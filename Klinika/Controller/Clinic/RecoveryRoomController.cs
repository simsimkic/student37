// File:    RecoveryRoomController.cs
// Created: Saturday, May 30, 2020 3:03:23 AM
// Purpose: Definition of Class RecoveryRoomController

using Model.Manager;
using Model.Patient;
using Service.Clinic;
using System;

namespace Controller.Clinic
{
   public class RecoveryRoomController
   {
        private readonly RecoveryRoomService _recoveryRoomService;

        public RecoveryRoomController(RecoveryRoomService service)
        {
            _recoveryRoomService = service;
        }

      public void AddRecovery(RecoveryRoom newRoom)
      {
         throw new NotImplementedException();
      }
      
      public void RemoveRecovery(string roomID)
      {
         throw new NotImplementedException();
      }
      
      public void PutPatient(Patient broughtPatient)
      {
         throw new NotImplementedException();
      }
      
      public void ReleasePatient(Patient releasedPatient)
      {
         throw new NotImplementedException();
      }
      
      public int EditCapacity(string roomID, int numberToChange)
      {
         throw new NotImplementedException();
      }
   }
}