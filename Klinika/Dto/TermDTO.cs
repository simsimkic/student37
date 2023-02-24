// File:    TermDTO.cs
// Created: Saturday, May 30, 2020 5:39:46 PM
// Purpose: Definition of Class TermDTO

using System;

namespace Dto
{
   public class TermDTO
   {
      public DateTime startDate { get; set; }
      public DateTime dueDate { get; set; }
   
        public TermDTO(DateTime start, DateTime due)
        {
            startDate = start;
            dueDate = due;
        }
   }
}