// File:    Equipment.cs
// Created: Thursday, April 9, 2020 9:59:00 PM
// Purpose: Definition of Class Equipment

using Klinika.Database;
using System;

namespace Model.Manager
{
    public class Equipment : IIdentifiable<string>
    {
        public string EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public EquipmentType Type { get; set; }
        public Status EStatus = Status.operative;
      
      public Reparation reparation;
      public Room room;
   
        public Equipment() { }

        public Equipment(string id)
        {
            EquipmentID = id;
        }

        public Equipment(string id, string name, EquipmentType etype, Status estatus, string roomID, DateTime dt)
        {
            EquipmentID = id;
            EquipmentName = name;
            Type = etype;
            EStatus = estatus;
            room = new Room(roomID);
            reparation = new Reparation(dt);
        }

        public string GetId() => EquipmentID;

        public void SetId(string id) => EquipmentID = id;
    }
}