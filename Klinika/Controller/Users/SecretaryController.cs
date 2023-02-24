// File:    SecretaryController.cs
// Created: Sunday, May 24, 2020 11:50:32 PM
// Purpose: Definition of Class SecretaryController

using Model.Manager;
using Model.Secretary;
using Model.User;
using Service.Users;
using System;

namespace Controller.Users
{
   public class SecretaryController
   {
      public SecretaryController(SecretaryService service)
        {
            secretaryService = service;
        }
      public WorkTime ViewWorkingTime(WorkTime workTime)
      {
         throw new NotImplementedException();
      }
      
      public void SetWorkingTime(WorkTime workTime)
      {
         throw new NotImplementedException();
      }
      
      public Schedule GetSchedule()
      {
         throw new NotImplementedException();
      }
      
      public void SetSchedule()
      {
         throw new NotImplementedException();
      }
      
      public User RegisterPatient(User user)
      {
         throw new NotImplementedException();
      }
      
      public User LoginPatient(string username, string password)
      {
         throw new NotImplementedException();
      }
      
      public void DeletePatient(User user)
      {
         throw new NotImplementedException();
      }
      
      public SecretaryService secretaryService;
   
   }
}