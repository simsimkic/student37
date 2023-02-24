// File:    RoomController.cs
// Created: Saturday, May 30, 2020 3:00:09 AM
// Purpose: Definition of Class RoomController

using Model.Manager;
using Service.Clinic;
using System;
using System.Collections.Generic;

namespace Controller.Clinic
{
   public class RoomController
   {
      private readonly RoomService _roomService;

      public RoomController(RoomService service)
      {
            _roomService = service;
      }

      public void AddRoom(Room newRoom)
            => _roomService.AddRoom(newRoom);
      
      public void EditRoom(Room room)
            => _roomService.EditRoom(room);
      
      public void RemoveRoom(string roomID)
            => _roomService.RemoveRoom(roomID);
      
      public Room GetRoom(string roomID)
            => _roomService.GetRoom(roomID);

      public List<Room> GetAllRooms()
            => _roomService.GetAllRooms();
      
      public List<Room> Search(List<string> words)
            => _roomService.Search(words);
      
      public List<Room> SearchByFilter(List<string> filters)
            => _roomService.SearchByFilter(filters);
   
   }
}