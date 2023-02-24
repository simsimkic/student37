// File:    WorkTimeController.cs
// Created: Thursday, May 28, 2020 4:29:55 PM
// Purpose: Definition of Class WorkTimeController

using Dto;
using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using Service.Employees;
using System;
using System.Collections.Generic;

namespace Controller.Employees
{
   public class WorkTimeController
   {
        private readonly WorkTimeService workTimeService;

        public WorkTimeController(WorkTimeService service)
        {
            workTimeService = service;
        }

        public void AddWorkTime(WorkTime newWorkTime)
              => workTimeService.AddWorkTime(newWorkTime);
      
      public void EditWorkTime(string jmbg)
      {
         throw new NotImplementedException();
      }

        public void RemoveWorkTime(long id)
              => workTimeService.RemoveWorkTime(id);

        public WorkTime GetWorkTime(long id)
              => workTimeService.GetWorkTime(id);

        public TermDTO FindEmployeeWTByDate(long id, DateTime workDate)
              => workTimeService.FindEmployeeWTByDate(id, workDate);

      
   }
}