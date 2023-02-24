// File:    IRecoveryRoomDao.cs
// Created: Wednesday, May 27, 2020 4:25:06 PM
// Purpose: Definition of Interface IRecoveryRoomDao

using Model.Manager;

namespace Dao.Clinic
{
   public interface IRecoveryRoomDao : ICRUDDao<RecoveryRoom, string>
   {
   }
}