// File:    RoomFuncService.cs
// Created: Wednesday, May 27, 2020 5:56:54 PM
// Purpose: Definition of Class RoomFuncService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Service.Clinic
{
   public class RoomFuncService
   {
        private readonly IRoomFuncDao _roomFuncDao;

        public RoomFuncService(IRoomFuncDao dao)
        {
            _roomFuncDao = dao;
        }

        public void AddFunc(Functionality newFunc)
        {
            Functionality f = _roomFuncDao.FindByName(newFunc.FuncName);
            if (f != null)
                _roomFuncDao.Save(newFunc);
        }

        public Functionality GetFunc(long id)
           => _roomFuncDao.FindById(id);

        public Functionality GetFunc(string funcName)
            => _roomFuncDao.FindByName(funcName);

        public List<Functionality> GetAllFunc()
            => (List<Functionality>) _roomFuncDao.FindAll();

      public List<Functionality> IsFuncOk(Functionality functionality, List<Room> rooms)
      {
         throw new NotImplementedException();
      }
   }
}