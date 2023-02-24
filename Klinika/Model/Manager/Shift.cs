// File:    Shift.cs
// Created: Thursday, April 16, 2020 6:33:23 PM
// Purpose: Definition of Class Shift

using System;
using System.Collections.Generic;

namespace Model.Manager
{
    public class Shift
    {
        public long Id { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public List<DayOfWeek> Days { get; set; }

        public Shift() {
        }

        public Shift(long id)
        {
            Id = id;
        }

        public Shift(long id, DateTime begin, DateTime end, List<DayOfWeek> days)
        {
            Id = id;
            Begin = begin;
            End = end;
            Days = days;
        }
   
    }
}