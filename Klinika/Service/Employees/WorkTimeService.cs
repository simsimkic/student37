// File:    WorkTimeService.cs
// Created: Thursday, May 28, 2020 4:29:55 PM
// Purpose: Definition of Class WorkTimeService

using Dao.Employees;
using Dao.Employees.CSVImpl;
using Dto;
using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Service.Employees
{
   public class WorkTimeService
   {
        private readonly IWorkTimeDao _workTimeDao;
        private readonly ShiftService _shiftService;

        public WorkTimeService(IWorkTimeDao wtDao, ShiftService shService)
        {
            _workTimeDao = wtDao;
            _shiftService = shService;
        }

        public void AddWorkTime(WorkTime newWorkTime)
      {
            foreach (Shift s in newWorkTime.shift)
                _shiftService.AddShift(s);
            _workTimeDao.Save(newWorkTime);
      }
            
 // TODO gojko: Obrisi?     
      public void EditWorkTime(WorkTime wt)
      {
         throw new NotImplementedException();
      }

      public void RemoveWorkTime(long id)
            => _workTimeDao.DeleteById(id);

      public WorkTime GetWorkTime(long id)
            => _workTimeDao.FindById(id);

        // TODO Gojko: Ime funkcije?
      public TermDTO FindEmployeeWTByDate(long id, DateTime workDate)
        {
            Shift shift;
            WorkTime wt = GetWorkTime(id);
            if (wt.FixShift)     // Ako je smena fiksirana gledam samo koja je smena Trenutna
                shift = wt.CurrShift == AssignedShift.iShift ? wt.shift[0] : wt.shift[1];
            else                 // Ako je broj ciklusa koji je prosao paran onda je trenutna smena prva, u suprotnom druga
                shift = ((workDate.Date.AddDays(1) - wt.CycleStartDate.Date).Days / wt.Cycle) % 2 == 0 ? wt.shift[0] : wt.shift[1];

            shift = _shiftService.GetShift(shift.Id);
            if (shift.Days.Contains(workDate.DayOfWeek))
                return new TermDTO(shift.Begin, shift.End);
            else
                return null;
        }

    }
}