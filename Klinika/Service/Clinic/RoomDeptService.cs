// File:    RoomDeptService.cs
// Created: Wednesday, May 27, 2020 5:56:54 PM
// Purpose: Definition of Class RoomDeptService

using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Manager;
using System;
using System.Collections.Generic;

namespace Service.Clinic
{
   public class RoomDeptService
   {
        private readonly IRoomDepartmentDao _roomDepartmentDao;

        public RoomDeptService(IRoomDepartmentDao dao)
        {
            _roomDepartmentDao = dao;
        }

        public void AddDept(Department newDept)
        {
            Department dept = _roomDepartmentDao.FindByName(newDept.DepName);
            if (dept != null)
                _roomDepartmentDao.Save(newDept);

        }

        public Department GetDept(long id)
            => _roomDepartmentDao.FindById(id);

        public Department GetDept(string deptName)
          => _roomDepartmentDao.FindByName(deptName);

      public List<Department> GetAllDept()
          => (List<Department>) _roomDepartmentDao.FindAll();
   }
}