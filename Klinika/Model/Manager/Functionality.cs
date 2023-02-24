// File:    Functionality.cs
// Created: Tuesday, April 21, 2020 7:57:09 PM
// Purpose: Definition of Class Functionality

using System;

namespace Model.Manager
{
   public class Functionality
   {
      public long Id { get; set; }
      public string FuncName { get; set; }
   
        public Functionality(long id)
        {
            Id = id;
        }
        public Functionality(long id, string name)
        {
            Id = id;
            FuncName = name;
        }
   }
}