// File:    ShiftController.cs
// Created: Thursday, May 28, 2020 4:29:55 PM
// Purpose: Definition of Class ShiftController

using Model.Manager;
using Service.Employees;
using System;
using System.Collections.Generic;

namespace Controller.Employees
{
   public class ShiftController
   {
        private readonly ShiftService _shiftService;

        public ShiftController(ShiftService service)
        {
            _shiftService = service;
        }
        public void AddShift(Shift newShift)
          => _shiftService.AddShift(newShift);

        public Shift GetShift(long id)
          => _shiftService.GetShift(id);

        public List<Shift> GetAllShifts()
          => _shiftService.GetAllShifts();   
   }
}