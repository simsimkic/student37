// File:    RecoveryRoomService.cs
// Created: Wednesday, May 27, 2020 4:57:44 PM
// Purpose: Definition of Class RecoveryRoomService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Manager;
using Model.Patient;
using System;

namespace Service.Clinic
{
   public class RecoveryRoomService
   {
        private readonly IRecoveryRoomDao _recoveryRoomDao;

        public RecoveryRoomService(IRecoveryRoomDao dao)
        {
            _recoveryRoomDao = dao;
        }

        public void AddRecovery(RecoveryRoom newRoom)
              => _recoveryRoomDao.Save(newRoom);

        public void RemoveRecovery(string roomID)
              => _recoveryRoomDao.DeleteById(roomID);
      
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
            RecoveryRoom rr = _recoveryRoomDao.FindById(roomID);
            rr.TotalSpots += numberToChange;
            _recoveryRoomDao.Save(rr);
            return rr.TotalSpots;
        }
   }
}