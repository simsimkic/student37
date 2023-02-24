// File:    IMedicineDao.cs
// Created: Sunday, May 24, 2020 9:40:55 PM
// Purpose: Definition of Interface IMedicineDao

using Model.Manager;

namespace Dao.Clinic
{
   public interface IMedicineDao : ICRUDDao<Medicine, string>
   {
   }
}