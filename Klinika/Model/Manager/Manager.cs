// File:    Manager.cs
// Created: Saturday, April 18, 2020 4:37:23 PM
// Purpose: Definition of Class Manager

using System;

namespace Model.Manager
{
   public class Manager : Model.User.User
   {
        public WorkTime workTime;
        public Manager(User.User user) : base(user) { }
   }
}