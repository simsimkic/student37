// File:    IManagerDao.cs
// Created: Sunday, May 24, 2020 10:03:16 PM
// Purpose: Definition of Interface IManagerDao

using Model.Manager;
using System;

namespace Dao.Users
{
   public interface IManagerDao : ICRUDDao<Manager, long>
   {
   }
}