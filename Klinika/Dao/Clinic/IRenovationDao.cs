// File:    IRenovationDao.cs
// Created: Wednesday, May 27, 2020 4:11:09 PM
// Purpose: Definition of Interface IRenovationDao

using Model.Manager;

namespace Dao.Clinic
{
   public interface IRenovationDao : ICRUDDao<Renovation, long>
   {
   }
}