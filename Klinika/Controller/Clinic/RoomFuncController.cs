// File:    RoomFuncController.cs
// Created: 27 May, 2020 17:56:54
// Purpose: Definition of Class RoomFuncController

using Model.Manager;
using Service.Clinic;
using System;
using System.Collections.Generic;

namespace Controller.Clinic
{
    public class RoomFuncController
    {
        private readonly RoomFuncService _roomFuncService;

        public RoomFuncController(RoomFuncService service)
        {
            _roomFuncService = service;
        }

        public void AddFunc(Functionality newFunc)
            => _roomFuncService.AddFunc(newFunc);

        public Functionality GetFunc(long id)
            => _roomFuncService.GetFunc(id);

        public Functionality GetFunc(string funcName)
            => _roomFuncService.GetFunc(funcName);

        public List<Functionality> GetAllFunc()
            => _roomFuncService.GetAllFunc();

        public List<Functionality> IsFuncOk(Functionality funcionality, List<Room> rooms)
        {
            throw new NotImplementedException();
        }
    }
}