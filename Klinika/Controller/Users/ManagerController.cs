// File:    ManagerService.cs
// Created: Thursday, May 28, 2020 10:21:41 PM
// Purpose: Definition of Class ManagerController

using Model.User;
using Service.Users;
using System;

namespace Controller.Users
{
   public class ManagerController
   {
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
      
      public ManagerService managerService;
   
   }
}