// File:    IRoomFuncDao.cs
// Created: Saturday, May 16, 2020 3:30:51 PM
// Purpose: Definition of Interface IRoomFuncDao

using Model.Manager;
using System;

namespace Dao.Clinic
{
   public interface IRoomFuncDao : ICRUDDao<Functionality, long>
   {
        Functionality FindByName(string name);
   }
}