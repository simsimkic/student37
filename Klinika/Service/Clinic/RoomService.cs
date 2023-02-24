// File:    RoomService.cs
// Created: Friday, May 15, 2020 9:54:28 PM
// Purpose: Definition of Class RoomService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Clinic
{
   public class RoomService
   {
        private readonly IRoomDao _roomDao;
        private readonly RoomDeptService _roomDeptService;
        private readonly RoomFuncService _roomFuncService;
        private readonly RecoveryRoomService _recoveryRoomService;
        private readonly EquipmentService _equipmentService;

        public RoomService(IRoomDao rDao, RoomDeptService deptService, RoomFuncService funcService, RecoveryRoomService rrService,
            EquipmentService eService)
        {
            _roomDao = rDao;
            _roomDeptService = deptService;
            _roomFuncService = funcService;
            _recoveryRoomService = rrService;
            _equipmentService = eService;
        }

        public void AddRoom(Room newRoom)
      {
            if (!_roomDao.ExistsById(newRoom.Id))
            {
                _roomDao.Save(newRoom);
                _roomDeptService.AddDept(newRoom.Department);
                _roomFuncService.AddFunc(newRoom.Functionality);
                foreach (Equipment e in newRoom.Equipment)
                {
                    _equipmentService.UpdateEquipmentLocation(e.EquipmentID, newRoom.Id);
                }
            }
      }
      
      public void EditRoom(Room room)
      {
            _roomDao.Save(room);
            _roomDeptService.AddDept(room.Department);
            _roomFuncService.AddFunc(room.Functionality);
            foreach (Equipment e in room.Equipment)
            {
                _equipmentService.UpdateEquipmentLocation(e.EquipmentID, room.Id);
            }
//TODO Gojko: Prebaciti opremu iz sobe u MA (default magacin)
        }
      
      public void RemoveRoom(string roomID)
      {
            _roomDao.DeleteById(roomID);
 //TODO Gojko: Prebaciti svu opremu iz sobe u MA (default magacin)
      }     
      
      public Room GetRoom(string roomID)
      {
            Room room = _roomDao.FindById(roomID);
            if(room != null)
            {
                for (int i = 0; i < room.Equipment.Count; i++)       //Prikupljanje Ostalih podataka opreme u zeljenoj sobi
                    room.Equipment[i] = _equipmentService.GetEquipment(room.Equipment[i].EquipmentID);
                room.Department = _roomDeptService.GetDept(room.Department.Id);
                room.Functionality = _roomFuncService.GetFunc(room.Functionality.Id);
            }    
            return room;
      }
            
      
      public List<Room> GetAllRooms()
        {
            List<Room> allRooms = new List<Room>();
            foreach (Room r in _roomDao.FindAll())
                allRooms.Add(GetRoom(r.Id));
            return allRooms;
        }

      public void PutEquipmentToRoom(string roomID, string equipmentID)
      {
            Room r = GetRoom(roomID);
            if (r == null)
                return;
            Equipment equip = r.Equipment.SingleOrDefault(e => e.EquipmentID.CompareTo(equipmentID) == 0);
            if(equip == null)
            {
                r.Equipment.Add(new Equipment(equipmentID));
                _roomDao.Save(r);
            }
      }

      public void RemoveEquipmentFromRoom(string roomID, string equipmentID)
        {
            Room r = GetRoom(roomID);
            Equipment equip = r.Equipment.SingleOrDefault(e => e.EquipmentID.CompareTo(equipmentID) == 0);
            if (equip != null)
            {
                r.Equipment.Remove(equip);
                _roomDao.Save(r);
            }
        }
      
      public List<Room> Search(List<string> words)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> SearchByFilter(List<string> filters)
      {
         throw new NotImplementedException();
      }
    }
}