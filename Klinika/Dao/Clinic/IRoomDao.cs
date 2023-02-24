// File:    IRoomDao.cs
// Created: Friday, May 15, 2020 8:36:32 PM
// Purpose: Definition of Interface IRoomDao

using Model.Manager;

namespace Dao.Clinic
{
   public interface IRoomDao : ICRUDDao<Room, string>
   {
   }
}