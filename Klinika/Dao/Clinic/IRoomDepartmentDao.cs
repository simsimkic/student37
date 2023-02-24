// File:    IRoomDepartmentDao.cs
// Created: Saturday, May 16, 2020 3:30:52 PM
// Purpose: Definition of Interface IRoomDepartmentDao

using Model.Manager;
using System;

namespace Dao.Clinic
{
   public interface IRoomDepartmentDao : Dao.ICRUDDao<Department, long>
   {
        Department FindByName(string name);
   }
}