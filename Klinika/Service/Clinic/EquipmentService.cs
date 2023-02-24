// File:    EquipmentService.cs
// Created: Friday, May 15, 2020 9:54:37 PM
// Purpose: Definition of Class EquipmentService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Service.Clinic
{
   public class EquipmentService
   {
        private readonly IEquipmentDao _equipmentDao;
        private readonly RoomService _roomService;
        
        public EquipmentService(IEquipmentDao equipmentDao, RoomService roomService)
        {
            _equipmentDao = equipmentDao;
            _roomService = roomService;
        }
        public void AddEquipment(Equipment newEquipment)
      {
            if (!_equipmentDao.ExistsById(newEquipment.EquipmentID))
            {
                _equipmentDao.Save(newEquipment);
                if (newEquipment.room.Id != null)
                    _roomService.PutEquipmentToRoom(newEquipment.room.Id, newEquipment.EquipmentID);
            }     
      }
      
      public void EditEquipment(Equipment equipment)
      {
            _equipmentDao.Save(equipment);
            _roomService.PutEquipmentToRoom(equipment.room.Id, equipment.EquipmentID);
// TODO Gojko: Izbaciti Opremu iz stare sobe
//          _roomService.RemoveEquipmentFromRoom(starasoba.Id, equipment.equipmentID);
      }
      
      public void RemoveEquipment(string equipmentID)
      {
            string roomID = GetEquipment(equipmentID).room.Id;
            _equipmentDao.DeleteById(equipmentID);
            _roomService.RemoveEquipmentFromRoom(roomID, equipmentID);
      }
            
      
      public Equipment GetEquipment(string equipmentID)
            => _equipmentDao.FindById(equipmentID);
      
      public List<Equipment> GetAllEquipment()
            => (List<Equipment>)_equipmentDao.FindAll();
      
      public void UpdateEquipmentLocation(string equipmentID, string roomID)
      {
            Equipment e = GetEquipment(equipmentID);
            e.room.Id = roomID;
            _equipmentDao.Save(e);
      }
      public void ScheduleReparation(List<string> iDs)
      {
         throw new NotImplementedException();
      }
      
      public void RetriveReraired(string equipmentID)
      {
         throw new NotImplementedException();
      }
      
      public List<Equipment> Search(List<string> words)
      {
         throw new NotImplementedException();
      }
      
      public List<Equipment> SearchByFilter(List<string> filters)
      {
         throw new NotImplementedException();
      }
    }
}