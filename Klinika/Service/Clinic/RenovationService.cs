// File:    RenovationService.cs
// Created: Wednesday, May 27, 2020 3:05:34 AM
// Purpose: Definition of Class RenovationService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Service.Clinic
{
   public class RenovationService
   {
        private readonly IRoomDao _roomDao;
        private readonly IRoomDao _renovationRoomDao;
        private readonly IRenovationDao _renovationDao;

        public RenovationService(IRoomDao roomDao, IRoomDao renovationroomDao, IRenovationDao renDao)
        {
            _roomDao = roomDao;
            _renovationRoomDao = renovationroomDao;
            _renovationDao = renDao;
        }

        public void AddRenovation(Renovation newRenovation)
      {
            _renovationDao.Save(newRenovation);
            if(newRenovation.RenType != RenovationType.standard)
            {
                _renovationRoomDao.SaveAll(newRenovation.newRooms);
            }
      }
      
      public void RemoveRenovation(long id)
      {
            _renovationDao.DeleteById(id);
      }

        public Renovation GetRenovation(long id)
          => _renovationDao.FindById(id);

        public List<Renovation> GetAllRenovations()
          => (List<Renovation>)_renovationDao.FindAll();
   }
}