// File:    IEquipmentDao.cs
// Created: Friday, May 15, 2020 8:53:58 PM
// Purpose: Definition of Interface IEquipmentDao

using Model.Manager;
using System;

namespace Dao.Clinic
{
   public interface IEquipmentDao : ICRUDDao<Equipment, string>
   {
   }
}