// File:    ShiftService.cs
// Created: Thursday, May 28, 2020 4:29:55 PM
// Purpose: Definition of Class ShiftService

using Dao.Employees;
using Dao.Employees.CSVImpl;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Service.Employees
{
   public class ShiftService
   {
        private readonly IShiftDao _shiftDao;

        public ShiftService(IShiftDao dao)
        {
            _shiftDao = dao;
        }

        public void AddShift(Shift newShift)
        {
            if(!_shiftDao.ExistsById(newShift.Id))
                 _shiftDao.Save(newShift);
        }
         

      public Shift GetShift(long id)
          => _shiftDao.FindById(id);

      public List<Shift> GetAllShifts()
          => (List<Shift>) _shiftDao.FindAll();
   }
}