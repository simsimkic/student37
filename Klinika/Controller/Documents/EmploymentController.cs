// File:    EmploymentController.cs
// Created: Tuesday, May 26, 2020 7:42:15 PM
// Purpose: Definition of Class EmploymentController

using Model.Patient;
using Service.Documents;
using System;
using System.Collections.Generic;

namespace Controller.Documents
{
   public class EmploymentController
   {
      public Employment AddEmployment(string jmbg, Employment employment)
      {
         throw new NotImplementedException();
      }
      
      public void RemoveEmployment()
      {
         throw new NotImplementedException();
      }
      
      public List<Employment> GetEmployments()
      {
         throw new NotImplementedException();
      }
      
      public EmploymentService employmentService;
   
   }
}