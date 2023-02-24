// File:    RoomDeptController.cs
// Created: 27 May, 2020 17:56:54
// Purpose: Definition of Class RoomDeptController

using Model.Manager;
using Service.Clinic;
using System;
using System.Collections.Generic;

namespace Controller.Clinic
{
    public class RoomDeptController
    {
        private readonly RoomDeptService _roomDeptService;

        public RoomDeptController(RoomDeptService service)
        {
            _roomDeptService = service;
        }
        
        public void AddDept(Department newDept)
            => _roomDeptService.AddDept(newDept);

        public Department GetDept(long id)
            => _roomDeptService.GetDept(id);

        public Department GetDept(string deptName)
            => _roomDeptService.GetDept(deptName);

        public List<Department> GetAllDept()
            => _roomDeptService.GetAllDept();
    }
}
