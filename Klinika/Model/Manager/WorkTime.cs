// File:    WorkTime.cs
// Created: Friday, April 17, 2020 10:07:05 PM
// Purpose: Definition of Class WorkTime

using System;

namespace Model.Manager
{
   public class WorkTime
   {
      public long Id { get; set; }
      public int Cycle { get; set; }
      public DateTime CycleStartDate { get; set; }
      public AssignedShift CurrShift { get; set; }
      public bool FixShift { get; set; }
      
      public System.Collections.Generic.List<Shift> shift;
      
      /// <summary>
      /// Property for collection of Shift
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Shift> Shift
      {
         get
         {
            if (shift == null)
               shift = new System.Collections.Generic.List<Shift>();
            return shift;
         }
         set
         {
            RemoveAllShift();
            if (value != null)
            {
               foreach (Shift oShift in value)
                  AddShift(oShift);
            }
         }
      }
      
      /// <summary>
      /// Add a new Shift in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddShift(Shift newShift)
      {
         if (newShift == null)
            return;
         if (this.shift == null)
            this.shift = new System.Collections.Generic.List<Shift>();
         if (!this.shift.Contains(newShift))
            this.shift.Add(newShift);
      }
      
      /// <summary>
      /// Remove an existing Shift from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveShift(Shift oldShift)
      {
         if (oldShift == null)
            return;
         if (this.shift != null)
            if (this.shift.Contains(oldShift))
               this.shift.Remove(oldShift);
      }
      
      /// <summary>
      /// Remove all instances of Shift from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllShift()
      {
         if (shift != null)
            shift.Clear();
      }

      public WorkTime() {
      }
      
      public WorkTime(long id)
        {
            Id = id;
        }



      public WorkTime(long id, int cycle, DateTime startDate, AssignedShift current, bool fix, Shift first, Shift second)
        {
            Id = id;
            Cycle = cycle;
            CycleStartDate = startDate;
            CurrShift = current;
            FixShift = fix;
            Shift.Add(first);
            Shift.Add(second);
        }
    }
}