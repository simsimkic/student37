// File:    Renovation.cs
// Created: Thursday, April 16, 2020 4:24:50 PM
// Purpose: Definition of Class Renovation

using System;

namespace Model.Manager
{
   public class Renovation
   {
      public long Id { get; set; }
      public DateTime BeginDate { get; set; }
      public DateTime DueDate { get; set; }
      public RenovationType RenType { get; set; }
      public int Parts { get; set; }
      
      public System.Collections.Generic.List<Room> newRooms;
      
      /// <summary>
      /// Property for collection of Room
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Room> NewRooms
      {
         get
         {
            if (newRooms == null)
               newRooms = new System.Collections.Generic.List<Room>();
            return newRooms;
         }
         set
         {
            RemoveAllNewRooms();
            if (value != null)
            {
               foreach (Room oRoom in value)
                  AddNewRooms(oRoom);
            }
         }
      }
      
      /// <summary>
      /// Add a new Room in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddNewRooms(Room newRoom)
      {
         if (newRoom == null)
            return;
         if (this.newRooms == null)
            this.newRooms = new System.Collections.Generic.List<Room>();
         if (!this.newRooms.Contains(newRoom))
            this.newRooms.Add(newRoom);
      }
      
      /// <summary>
      /// Remove an existing Room from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveNewRooms(Room oldRoom)
      {
         if (oldRoom == null)
            return;
         if (this.newRooms != null)
            if (this.newRooms.Contains(oldRoom))
               this.newRooms.Remove(oldRoom);
      }
      
      /// <summary>
      /// Remove all instances of Room from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllNewRooms()
      {
         if (newRooms != null)
            newRooms.Clear();
      }
      public Room[] room;

        public Renovation() { }

        public Renovation(long id)
        {
            Id = id;
        }

        public Renovation(long id, DateTime begin, DateTime end, RenovationType type, int parts)
        {
            Id = id;
            BeginDate = begin;
            DueDate = end;
            RenType = type;
            Parts = parts;
        }
   
   }
}