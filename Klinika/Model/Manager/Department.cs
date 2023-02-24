// File:    Department.cs
// Created: Tuesday, April 21, 2020 7:57:06 PM
// Purpose: Definition of Class Department

using System;

namespace Model.Manager
{
   public class Department
   {
      public long Id { get; set; }
      public string DepName { get; set; }

        public Department(long id)
        {
            Id = id;
        }
   
        public Department(long id, string name)
        {
            Id = id;
            DepName = name;
        }
   }
}