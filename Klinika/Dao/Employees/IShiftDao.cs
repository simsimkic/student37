// File:    IShiftDao.cs
// Created: Wednesday, May 27, 2020 7:25:35 PM
// Purpose: Definition of Interface IShiftDao

using Model.Manager;

namespace Dao.Employees
{
   public interface IShiftDao : ICRUDDao<Shift, long>
   {
   }
}